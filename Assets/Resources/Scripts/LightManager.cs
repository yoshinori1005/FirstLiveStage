using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    [SerializeField] private List<Light> lights;

    // 赤に変更
    public void SetLightColorRed()
    {
        SetColor(Color.red);
    }

    // 緑に変更
    public void SetLightColorGreen()
    {
        SetColor(Color.green);
    }

    // 青に変更
    public void SetLightColorBlue()
    {
        SetColor(Color.blue);
    }

    // 白に変更
    public void SetLightColorWhite()
    {
        SetColor(Color.white);
    }

    // 色を一括で変更する内部関数
    private void SetColor(Color newColor)
    {
        foreach (Light light in lights)
        {
            if (light != null)
            {
                light.color = newColor;
            }
        }
    }
}
