using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class CartManager : MonoBehaviour
{
    private bool open = false;

    [SerializeField] private GameObject CartUI;
    public List<Glasses> glasses;
    [SerializeField] private TextMeshProUGUI totalCostText;
    public int totalCost = 0;
    public GameObject cartGameObject;
    private List<CartItem> items;

    private void Start()
    {
        items = cartGameObject.GetComponentsInChildren<CartItem>().ToList();
    }

    private void Update()
    {
        glasses = ChosenGlasses.glassesInCart;

        for (int i = 0; i<glasses.Count; i++)
        {
            items[i].UpdateInfo(glasses[i]);
        }

        foreach(CartItem cartItem in items)
        {
            if (cartItem.updated == false) {
                cartItem.gameObject.SetActive(false);
            }
            else
            {
                cartItem.gameObject.SetActive(true);
            }
        }

        totalCost = CalculateTotal();
        totalCostText.text = "Total: " + totalCost.ToString() + "$";
    }

    public int CalculateTotal()
    {
        return (int)glasses.Sum(g => g.cost);
    }

    public void OpenAndClose()
    {
        if (open)
        {
            CartUI.transform.localPosition = new Vector3(1352.048f, 2.14f, 0);
            
            open = false;
        }
        else
        {
            CartUI.transform.localPosition = new Vector3(593.0764f, 2.14f, 0);
            open = true;
        }
    }
}
