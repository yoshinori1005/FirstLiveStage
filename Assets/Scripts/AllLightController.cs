using System.Collections.Generic;
using UnityEngine;

public class AllLightController : MonoBehaviour
{
    List<RightLightController> rightLights;
    List<CenterLightController> centerLights;
    List<LeftLightController> leftLights;

    Animator[] animators;
    bool isBlinking = false;

    public enum LightColor
    {
        Base, Red, Green, Blue
    }

    public enum BlinkType
    {
        Off, Low, Mid, High
    }

    void Start()
    {
        animators = GetComponentsInChildren<Animator>();
        rightLights = new List<RightLightController>(FindObjectsOfType<RightLightController>());
        centerLights = new List<CenterLightController>(FindObjectsOfType<CenterLightController>());
        leftLights = new List<LeftLightController>(FindObjectsOfType<LeftLightController>());
    }

    // 指定したライト以外を基本色にするメソッド
    public void SetOtherLightsToBase(string exclude)
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
            case BlinkType.Off: return colorName + "BlinkOff";
            case BlinkType.Low: return colorName + "BlinkLow";
            case BlinkType.Mid: return colorName + "BlinkMid";
            case BlinkType.High: return colorName + "BlinkHigh";
            default: return colorName + "BlinkOff";
        }
    }

    // 基本色統一メソッド
    public void AllBaseColor()
    {
        string colorName = "On" + GetColorName(LightColor.Base);

        foreach (Animator animator in animators)
        {
            animator.SetTrigger(colorName);
        }
    }

    // 赤色統一メソッド
    public void AllRedColor()
    {
        string colorName = "On" + GetColorName(LightColor.Red);

        foreach (Animator animator in animators)
        {
            animator.SetTrigger(colorName);
        }
    }

    // 緑色統一メソッド
    public void AllGreenColor()
    {
        string colorName = "On" + GetColorName(LightColor.Green);

        foreach (Animator animator in animators)
        {
            animator.SetTrigger(colorName);
        }
    }

    // 青色統一メソッド
    public void AllBlueColor()
    {
        string colorName = "On" + GetColorName(LightColor.Blue);

        foreach (Animator animator in animators)
        {
            animator.SetTrigger(colorName);
        }
    }

    // 点滅開始メソッド
    public void StartBlinking(BlinkType blinkType, LightColor color)
    {
        isBlinking = true;
        string typeBlink = GetBlinkType(blinkType, color);

        foreach (Animator animator in animators)
        {
            animator.SetTrigger(typeBlink);
        }
    }

    // 点滅終了メソッド
    public void StopBlinking(LightColor color)
    {
        string colorName = GetColorName(color);

        if (isBlinking)
        {
            isBlinking = false;
            foreach (Animator animator in animators)
            {
                animator.SetTrigger(colorName + "BlinkOff");
            }
        }
    }

    // 基本色点滅オフメソッド
    public void BaseBlinkOff()
    {
        StopBlinking(LightColor.Base);
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

    // 赤色点滅オフメソッド
    public void RedBlinkOff()
    {
        StopBlinking(LightColor.Red);
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

    // 緑色点滅オフメソッド
    public void GreenBlinkOff()
    {
        StopBlinking(LightColor.Green);
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

    // 青色点滅オフメソッド
    public void BlueBlinkOff()
    {
        StopBlinking(LightColor.Blue);
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

    // 特定のトリガーが存在するか確認するメソッド
    private bool HasParameter(Animator animator, string paramName)
    {
        foreach (AnimatorControllerParameter param in animator.parameters)
        {
            if (param.name == paramName)
            {
                return true;
            }
        }
        return false;
    }

    // 初期設定のライト状態にするメソッド
    public void ResetColor()
    {
        foreach (Animator animator in animators)
        {
            if (HasParameter(animator, "OnColorful"))
            {
                animator.SetTrigger("OnColorful");
            }
            else
            {
                animator.SetTrigger("OnBase");
            }
        }
    }
}