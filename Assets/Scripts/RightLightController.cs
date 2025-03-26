using System.Collections;
using UnityEngine;

public class RightLightController : MonoBehaviour
{
    Animator[] animators;
    AllLightController allLightController;

    void Start()
    {
        animators = GetComponentsInChildren<Animator>();
        allLightController = FindObjectOfType<AllLightController>();
    }

    // 右側基本色メソッド
    public void RightBaseColor()
    {
        if (allLightController.IsBlinkingOrReset())
        {
            allLightController.SetOtherLightsToBase("Right");
        }

        SetColor("OnBase");
    }

    // 右側赤色メソッド
    public void RightRedColor()
    {
        if (allLightController.IsBlinkingOrReset())
        {
            allLightController.SetOtherLightsToBase("Right");
        }

        SetColor("OnRed");
    }

    // 右側緑色メソッド
    public void RightGreenColor()
    {
        if (allLightController.IsBlinkingOrReset())
        {
            allLightController.SetOtherLightsToBase("Right");
        }

        SetColor("OnGreen");
    }

    // 右側青色メソッド
    public void RightBlueColor()
    {
        if (allLightController.IsBlinkingOrReset())
        {
            allLightController.SetOtherLightsToBase("Right");
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