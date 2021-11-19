using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public int[,] shopItems = new int[5,5];
    public TextMeshProUGUI coinText;

    // Start is called before the first frame update
    void Start()
    {
        // set nilai coin
        coinText.text = PlayerPrefsManager.instance.GetCoins().ToString();
        
        // ID's
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;

        // Price's
        shopItems[2, 1] = 1000;
        shopItems[2, 2] = 2000;
        shopItems[2, 3] = 3000;

        // Quantity's
        shopItems[3, 1] = 0;
        shopItems[3, 2] = 0;
        shopItems[3, 3] = 0;
    }

    private void Update()
    {
        // Update nilai coin
        coinText.text = PlayerPrefsManager.instance.GetCoins().ToString();
    }

    private void Transaction()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        // coin saat ini dikurang harga coin
        PlayerPrefsManager.instance.SetCoins(PlayerPrefsManager.instance.GetCoins() - shopItems[2, ButtonRef.GetComponent<ButtonInfo>().itemId]);

        // simpan dan | ambil dan tambahkan kuantitas item dengan id
        PlayerPrefsManager.instance.SetQuantityItemsWithId(ButtonRef.GetComponent<ButtonInfo>().itemId, PlayerPrefsManager.instance.GetQuantityItemsWithId(ButtonRef.GetComponent<ButtonInfo>().itemId) + 1);

        // tampilkan kuantitas terbaru
        ButtonRef.GetComponent<ButtonInfo>().quantityTxt.text = PlayerPrefsManager.instance.GetQuantityItemsWithId(ButtonRef.GetComponent<ButtonInfo>().itemId).ToString();
    }

    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (PlayerPrefsManager.instance.GetCoins() >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().itemId])
        {
            Transaction();
        }
    }

    public void BuyOnceAtZeroQty()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (PlayerPrefsManager.instance.GetQuantityItemsWithId(ButtonRef.GetComponent<ButtonInfo>().itemId) == 0)
        {
            if (PlayerPrefsManager.instance.GetCoins() >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().itemId])
            {
                Transaction();
            }
        }
        
    }

    public void BuyOnceOnly()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (PlayerPrefsManager.instance.GetBuyOnceOnlyWithId(ButtonRef.GetComponent<ButtonInfo>().itemId) == 0)
        {
            if (PlayerPrefsManager.instance.GetCoins() >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().itemId])
            {
                Transaction();
                // set buy only once
                PlayerPrefsManager.instance.SetBuyOnceOnlyWithId(ButtonRef.GetComponent<ButtonInfo>().itemId, 1);
            }
        }
        
    }

    public void UseItem()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (PlayerPrefsManager.instance.GetQuantityItemsWithId(ButtonRef.GetComponent<ButtonInfo>().itemId) > 0)
        {
            // kurangi kuantitas
            PlayerPrefsManager.instance.SetQuantityItemsWithId(ButtonRef.GetComponent<ButtonInfo>().itemId, PlayerPrefsManager.instance.GetQuantityItemsWithId(ButtonRef.GetComponent<ButtonInfo>().itemId) - 1);

            // tampilkan kuantitas terbaru
            ButtonRef.GetComponent<ButtonInfo>().quantityTxt.text = PlayerPrefsManager.instance.GetQuantityItemsWithId(ButtonRef.GetComponent<ButtonInfo>().itemId).ToString();
        }
    }
}
