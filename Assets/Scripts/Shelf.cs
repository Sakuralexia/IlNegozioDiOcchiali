using TMPro;
using UnityEngine;

public class Shelf : MonoBehaviour
{
    public TextMeshProUGUI costText;
    public TextMeshProUGUI brandText;
    public TextMeshProUGUI modelText;
    public TextMeshProUGUI colorText;
    public TextMeshProUGUI popularityText;
    public GameObject door;

    public void GlassesInformation(Glasses glasses)
    {
        costText.text = "Cost:\n" + glasses.cost.ToString() + "$";
        brandText.text = "Brand:\n" + glasses.brand.ToString();
        modelText.text = "Model:\n" + glasses.model.ToString();
        colorText.text = "Color:\n" + glasses.color.ToString();
        popularityText.text = glasses.popularity.ToString() + "/5 stars";
    }

   
    void Update()
    {
        if (IsMouseHovering())
        {
            door.transform.eulerAngles = new Vector3(transform.eulerAngles.x, 100f, transform.eulerAngles.z);
        }
        else
        {
            door.transform.eulerAngles = new Vector3(transform.eulerAngles.x, 90f, transform.eulerAngles.z);
        }
    }

    private bool IsMouseHovering()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            return hit.collider.gameObject == this.gameObject;
        }

        return false;
    }
}
