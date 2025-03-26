using System.Collections;
using UnityEngine;

public class LeftLightController : MonoBehaviour
{
    Animator[] animators;
    AllLightController allLightController;

    void Start()
    {
        animators = GetComponentsInChildren<Animator>();
        allLightController = FindObjectOfType<AllLightController>();
    }

    // 左側基本色メソッド
    public void LeftBaseColor()
    {
        if (allLightController.IsBlinkingOrReset())
        {
            allLightController.SetOtherLightsToBase("Left");
        }

        SetColor("OnBase");
    }

    // 左側赤色メソッド
    public void LeftRedColor()
    {
        if (allLightController.IsBlinkingOrReset())
        {
            allLightController.SetOtherLightsToBase("Left");
        }

        SetColor("OnRed");
    }

    // 左側緑色メソッド
    public void LeftGreenColor()
    {
        if (allLightController.IsBlinkingOrReset())
        {
            allLightController.SetOtherLightsToBase("Left");
        }

        SetColor("OnGreen");
    }

    // 左側青色メソッド
    public void LeftBlueColor()
    {
        if (allLightController.IsBlinkingOrReset())
        {
            allLightController.SetOtherLightsToBase("Left");
        }

        SetColor("OnBlue");
    }

    // 指定した箇所以外の色を基本色にするメソッド
    public void SetBaseColor()
    {
        SetColor("OnBase");
        // StartCoroutine(SetBaseColorWithDelay());
    }

    // 点滅を終了して基本色にするメソッド
    // IEnumerator SetBaseColorWithDelay()
    // {
    //     foreach (Animator animator in animators)
    //     {
    //         animator.SetTrigger("BaseBlinkOff");
    //     }

    //     yield return null;
    //     SetColor("OnBase");
    // }

    // 色を変更するメソッド
    private void SetColor(string color)
    {
        foreach (Animator animator in animators)
        {
            animator.SetTrigger(color);
        }
    }
}