using System.Collections.Generic;
using UnityEngine;

public class AllLightController : MonoBehaviour
{
    List<RightLightController> rightLights;
    List<CenterLightController> centerLights;
    List<LeftLightController> leftLights;

    Animator[] animators;

    bool isBlinking = false;
    bool isReset = false;
    bool isAllColor = false;

    public enum LightColor
    {
        Base, Red, Green, Blue
    }

    public enum BlinkType
    {
        Low, Mid, High
    }

    void Start()
    {
        rightLights = new List<RightLightController>(FindObjectsOfType<RightLightController>());
        centerLights = new List<CenterLightController>(FindObjectsOfType<CenterLightController>());
        leftLights = new List<LeftLightController>(FindObjectsOfType<LeftLightController>());
        animators = GetComponentsInChildren<Animator>();

        ResetColor();
    }

    // 初期設定のライト状態にするメソッド
    public void ResetColor()
    {
        isReset = true;
        isBlinking = false;
        isAllColor = false;

        foreach (Animator animator in animators)
        {
            animator.SetTrigger("OnColorful");
        }
    }

    // 現在の状態を判定するメソッド(点滅中またはリセット)
    public bool IsBlinkingOrReset()
    {
        return isBlinking || isReset;
    }

    // 指定したライト以外を基本色にするメソッド
    public void SetOtherLightsToBase(string exclude)
    {
        if (isAllColor) return;

        if (isBlinking || isReset)
        {
            if (exclude != "Right")
            {
                foreach (RightLightController light in rightLights)
                {
                    light.SetBaseColor();
                }
            }
            if (exclude != "Center")
            {
                foreach (CenterLightController light in centerLights)
                {
                    light.SetBaseColor();
                }
            }
            if (exclude != "Left")
            {
                foreach (LeftLightController light in leftLights)
                {
                    light.SetBaseColor();
                }
            }
        }
    }

    // enum の色の名前を取得するメソッド
    private string GetColorName(LightColor color)
    {
        switch (color)
        {
            case LightColor.Base: return "Base";
            case LightColor.Red: return "Red";
            case LightColor.Green: return "Green";
            case LightColor.Blue: return "Blue";
            default: return "Base";
        }
    }

    // enum の点滅タイプを取得するメソッド
    private string GetBlinkType(BlinkType blinkType, LightColor color)
    {
        string colorName = GetColorName(color);

        switch (blinkType)
        {
            case BlinkType.Low: return colorName + "BlinkLow";
            case BlinkType.Mid: return colorName + "BlinkMid";
            case BlinkType.High: return colorName + "BlinkHigh";
            default: return colorName + "BlinkOff";
        }
    }

    // 全箇所を一色にするメソッド
    public void AllSetColor(LightColor color)
    {
        isBlinking = false;
        isAllColor = true;

        string colorName = "On" + GetColorName(color);

        foreach (Animator animator in animators)
        {
            animator.SetTrigger(colorName);
        }
    }

    // 基本色統一メソッド
    public void AllBaseColor()
    {
        AllSetColor(LightColor.Base);
    }

    // 赤色統一メソッド
    public void AllRedColor()
    {
        AllSetColor(LightColor.Red);
    }

    // 緑色統一メソッド
    public void AllGreenColor()
    {
        AllSetColor(LightColor.Green);
    }

    // 青色統一メソッド
    public void AllBlueColor()
    {
        AllSetColor(LightColor.Blue);
    }

    // 点滅開始メソッド
    public void StartBlinking(BlinkType blinkType, LightColor color)
    {
        isBlinking = true;
        isAllColor = false;
        string typeBlink = GetBlinkType(blinkType, color);

        foreach (Animator animator in animators)
        {
            animator.SetTrigger(typeBlink);
        }
    }

    // 点滅終了メソッド
    public void StopBlinking()
    {
        if (isBlinking)
        {
            isBlinking = false;
            foreach (Animator animator in animators)
            {
                animator.SetTrigger("OnBase");
            }
        }
    }

    // 基本色点滅スローテンポメソッド
    public void BaseBlinkLow()
    {
        StartBlinking(BlinkType.Low, LightColor.Base);
    }

    // 基本色点滅ミドルテンポメソッド
    public void BaseBlinkMid()
    {
        StartBlinking(BlinkType.Mid, LightColor.Base);
    }

    // 基本色点滅ハイテンポメソッド
    public void BaseBlinkHigh()
    {
        StartBlinking(BlinkType.High, LightColor.Base);
    }

    // 赤色点滅スローテンポメソッド
    public void RedBlinkLow()
    {
        StartBlinking(BlinkType.Low, LightColor.Red);
    }

    // 赤色点滅ミドルテンポメソッド
    public void RedBlinkMid()
    {
        StartBlinking(BlinkType.Mid, LightColor.Red);
    }

    // 赤色点滅ハイテンポメソッド
    public void RedBlinkHigh()
    {
        StartBlinking(BlinkType.High, LightColor.Red);
    }

    // 緑色点滅スローテンポメソッド
    public void GreenBlinkLow()
    {
        StartBlinking(BlinkType.Low, LightColor.Green);
    }

    // 緑色点滅ミドルテンポメソッド
    public void GreenBlinkMid()
    {
        StartBlinking(BlinkType.Mid, LightColor.Green);
    }

    // 緑色点滅ハイテンポメソッド
    public void GreenBlinkHigh()
    {
        StartBlinking(BlinkType.High, LightColor.Green);
    }

    // 青色点滅スローテンポメソッド
    public void BlueBlinkLow()
    {
        StartBlinking(BlinkType.Low, LightColor.Blue);
    }

    // 青色点滅ミドルテンポメソッド
    public void BlueBlinkMid()
    {
        StartBlinking(BlinkType.Mid, LightColor.Blue);
    }

    // 青色点滅ハイテンポメソッド
    public void BlueBlinkHigh()
    {
        StartBlinking(BlinkType.High, LightColor.Blue);
    }
}