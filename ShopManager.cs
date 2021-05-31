using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    //public int playerMoney.money;
    public TMP_Text coinUI;
    public ShopItemSO[] shopItemsSO;
    public ShopTemplate[] shopPanels;
    public GameObject[] shopPanelsGO;
    public Button[] myPurchaseBtns;

    //reference to player money script
    public PlayerMoney playerMoney;


    private void Start()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
            shopPanelsGO[i].SetActive(true);

        playerMoney = GameObject.Find("player").GetComponent<PlayerMoney>();
        //playerMoney.money
        coinUI.text = "Coins: " + playerMoney.money.ToString();
        LoadPanels();
    }

    public void AddCoins() //add playerMoney.money
    {
        playerMoney.money++;
            coinUI.text = "Coins: " + playerMoney.money.ToString();
        CheckPurchaseable();
    }

    public void CheckPurchaseable()
    {
        for (int i=0; i < shopItemsSO.Length; i++)
        {
            if (playerMoney.money >= shopItemsSO[i].baseCost) //if I have enough money
                myPurchaseBtns[i].interactable = true;
            else
                myPurchaseBtns[i].interactable = false;
        }
    }
    public void LoadPanels()
    {
        for (int i =0; i<shopItemsSO.Length; i++)
        {
            shopPanels[i].titleTMP.text = shopItemsSO[i].title;
            shopPanels[i].descriptionTMP.text = shopItemsSO[i].description;
            shopPanels[i].costTMP.text = "Coins: " + shopItemsSO[i].baseCost.ToString();
        }
    }

    public void PurchaseItem(int btnNo)
    {
        if (playerMoney.money >= shopItemsSO[btnNo].baseCost)
        {
            playerMoney.money = playerMoney.money - shopItemsSO[btnNo].baseCost;
            coinUI.text = "Coins: " + playerMoney.money.ToString();
            CheckPurchaseable();
        }
    }


}
