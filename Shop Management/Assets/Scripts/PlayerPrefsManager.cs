using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{
    // digunakan untuk menyimpan data jika pemain keluar game maka data tetap tersimpan
    #region Singleton
    public static PlayerPrefsManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    // reset save data
    public void ResetPrefs()
    {
        PlayerPrefs.DeleteAll();
    }

    // coins
    public int GetCoins()
    {
        return PlayerPrefs.GetInt("Coins", 50000);
    }
    public int SetCoins(int coins)
    {
        PlayerPrefs.SetInt("Coins", coins);
        return GetCoins();
    }

    // qty item yg dimiliki
    public int GetQuantityItemsWithId(int id)
    {
        return PlayerPrefs.GetInt("ItemsId" + id, 0);
    }

    public int SetQuantityItemsWithId(int id, int qty)
    {
        PlayerPrefs.SetInt("ItemsId" + id, qty);
        return GetQuantityItemsWithId(id);
    }

    public int GetBuyOnceOnlyWithId(int id)
    {
        return PlayerPrefs.GetInt("BuyOnceOnly" + id, 0);
    }

    public int SetBuyOnceOnlyWithId(int id, int boolean)
    {
        PlayerPrefs.SetInt("BuyOnceOnly" + id, boolean);
        return GetBuyOnceOnlyWithId(id);
    }
}
