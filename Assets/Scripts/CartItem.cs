using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CartItem : MonoBehaviour
{
    public bool updated = false;
    public TextMeshProUGUI cost;
    public TextMeshProUGUI glassesName;
    public TextMeshProUGUI brand;
    public TextMeshProUGUI model;
    public Image image;

    public void UpdateInfo(Glasses glasses)
    {
        updated = true;
        cost.text = glasses.cost + "$";
        glassesName.text = glasses.glassesName;
        brand.text = glasses.brand.ToString();
        model.text = glasses.model.ToString();

        switch (glasses.color)
        {
            case GlassesColor.Red:
                image.color = Color.red;
                break;
            case GlassesColor.Blue:
                image.color = Color.blue;
                break;
            case GlassesColor.Green:
                image.color = Color.green;
                break;
            case GlassesColor.Purple:
                image.color = Color.purple;
                break;
            case GlassesColor.Yellow:
                image.color = Color.yellow;
                break;

        }
    }
}
