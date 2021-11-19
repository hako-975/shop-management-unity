using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonInfo : MonoBehaviour
{
    public int itemId;
    public TextMeshProUGUI priceTxt;
    public TextMeshProUGUI quantityTxt;
    public GameObject shopManager;

    void Start()
    {
        priceTxt.text = "Rp. " + shopManager.GetComponent<ShopManager>().shopItems[2, itemId].ToString();
        quantityTxt.text = PlayerPrefsManager.instance.GetQuantityItemsWithId(itemId).ToString();
    }

    void Update()
    {
        priceTxt.text = "Rp. " + shopManager.GetComponent<ShopManager>().shopItems[2, itemId].ToString();
        quantityTxt.text = PlayerPrefsManager.instance.GetQuantityItemsWithId(itemId).ToString();
    }
}
