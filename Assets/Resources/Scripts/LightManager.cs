using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    [SerializeField] private List<Light> lights;
    [SerializeField] private float lightStrength = 2;
    [SerializeField] private PsylliumManager psylliumManager;

    // 各ライトの元のIntensityを保存
    private Dictionary<Light, float> originalIntensity = new Dictionary<Light, float>();

    void Start()
    {
        foreach (Light light in lights)
        {
            if (light != null && !originalIntensity.ContainsKey(light))
            {
                originalIntensity.Add(light, light.intensity);
            }
        }
    }

    // 赤に変更
    public void SetLightColorRed()
    {
        ResetIntensity();
        SetColor(Color.red);
        psylliumManager.ShowOnly(psylliumManager.GetRed());
    }

    // 緑に変更
    public void SetLightColorGreen()
    {
        ResetIntensity();
        SetColor(Color.green);
        psylliumManager.ShowOnly(psylliumManager.GetGreen());
    }

    // 青に変更
    public void SetLightColorBlue()
    {
        Color customBlue = new Color(0f, 0.5f, 1f, 1f);
        SetColor(customBlue);
        BoostIntensity(lightStrength);
        psylliumManager.ShowOnly(psylliumManager.GetBlue());
    }

    // 白に変更
    public void SetLightColorWhite()
    {
        ResetIntensity();
        SetColor(Color.white);
        psylliumManager.ShowOnly(psylliumManager.GetWhite());
    }

    // 基本状態に変更
    public void SetLightColorful()
    {
        ResetIntensity();
        SetColor(Color.white);
        psylliumManager.ShowOnly(psylliumManager.GetColorful());
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

    private void BoostIntensity(float value)
    {
        foreach (Light light in lights)
        {
            if (light != null && originalIntensity.ContainsKey(light))
            {
                light.intensity = originalIntensity[light] + value;
            }
        }
    }

    private void ResetIntensity()
    {
        foreach (Light light in lights)
        {
            if (light != null && originalIntensity.ContainsKey(light))
            {
                light.intensity = originalIntensity[light];
            }
        }
    }
}
