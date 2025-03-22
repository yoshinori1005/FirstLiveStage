using System.Collections;
using UnityEngine;

public class CenterLightController : MonoBehaviour
{
    Animator[] animators;
    AllLightController allLightController;

    void Start()
    {
        animators = GetComponentsInChildren<Animator>();
        allLightController = FindObjectOfType<AllLightController>();
    }

    // 中央基本色メソッド
    public void CenterBaseColor()
    {
        allLightController.SetOtherLightsToBase("Center");
        SetColor("OnBase");
    }

    // 中央赤色メソッド
    public void CenterRedColor()
    {
        allLightController.SetOtherLightsToBase("Center");
        SetColor("OnRed");
    }

    // 中央緑色メソッド
    public void CenterGreenColor()
    {
        allLightController.SetOtherLightsToBase("Center");
        SetColor("OnGreen");
    }

    // 中央青色メソッド
    public void CenterBlueColor()
    {
        allLightController.SetOtherLightsToBase("Center");
        SetColor("OnBlue");
    }

    // 指定した箇所以外の色を基本色にするメソッド
    public void SetBaseColor()
    {
        StartCoroutine(SetBaseColorWithDelay());
    }

    // 点滅を終了して基本色にするメソッド
    IEnumerator SetBaseColorWithDelay()
    {
        foreach (Animator animator in animators)
        {
            animator.SetTrigger("BaseBlinkOff");
        }

        yield return null;
        SetColor("OnBase");
    }

    // 色を変更するメソッド
    private void SetColor(string color)
    {
        foreach (Animator animator in animators)
        {
            animator.SetTrigger(color);
        }
    }
}