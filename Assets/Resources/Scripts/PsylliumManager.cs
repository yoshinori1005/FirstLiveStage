using UnityEngine;

public class PsylliumManager : MonoBehaviour
{
    [SerializeField] private GameObject red;
    [SerializeField] private GameObject green;
    [SerializeField] private GameObject blue;
    [SerializeField] private GameObject white;
    [SerializeField] private GameObject colorful;

    public void ShowOnly(GameObject target)
    {
        red?.SetActive(false);
        green?.SetActive(false);
        blue?.SetActive(false);
        white?.SetActive(false);
        colorful?.SetActive(false);

        if (target != null)
        {
            target.SetActive(true);
        }
    }

    public GameObject GetRed() => red;
    public GameObject GetGreen() => green;
    public GameObject GetBlue() => blue;
    public GameObject GetWhite() => white;
    public GameObject GetColorful() => colorful;
}
