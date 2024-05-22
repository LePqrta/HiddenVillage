using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameMarket : MonoBehaviour
{
    public GameObject marketCanvas; // Reference to the market UI canvas
    private CharacterControl characterControl; // Reference to the CharacterControl script
    private PlayerData playerData;
    public List<ItemData> availableItems = new List<ItemData>(); // List of available items in the market
    public GameObject itemPrefab; // Reference to the item UI prefab

    private void Start()
    {

        characterControl = FindObjectOfType<CharacterControl>();
        playerData = characterControl.GetComponent<PlayerData>();
        marketCanvas.SetActive(false);
    }

    [System.Serializable]
    public class ItemData
    {
        public string name;
        public int cost;
        public int sellPrice;
    }

    public class PlayerData : MonoBehaviour
    {
        public int money = 100;
        public List<ItemData> inventory = new List<ItemData>();
    }

    public void OpenMarket(GameObject character)
    {
        marketCanvas.SetActive(true);
        Text moneyText = marketCanvas.transform.Find("MoneyText").GetComponent<Text>();
        moneyText.text = "Money: " + playerData.money.ToString();

        Transform itemsContainer = marketCanvas.transform.Find("ItemsContainer");

        foreach (Transform child in itemsContainer)
        {
            Destroy(child.gameObject);
        }

        // Instantiate UI elements for each available item
        foreach (ItemData item in availableItems)
        {
            GameObject itemUI = Instantiate(itemPrefab, itemsContainer);
            itemUI.GetComponent<ItemUI>().SetItemData(item);
        }
    }

    public void BuyItem(ItemData itemData)
    {

        if (playerData.money >= itemData.cost)
        {

            playerData.money -= itemData.cost;
            playerData.inventory.Add(itemData);
            Debug.Log("Bought " + itemData.name + " for " + itemData.cost + " money.");
        }
        else
        {
            Debug.Log("Not enough money to buy " + itemData.name);
        }
    }

    public void SellItem(ItemData itemData)
    {
        if (playerData.inventory.Contains(itemData))
        {
            playerData.money += itemData.sellPrice;
            playerData.inventory.Remove(itemData);
            Debug.Log("Sold " + itemData.name + " for " + itemData.sellPrice + " money.");
        }
        else
        {
            Debug.Log("You don't have " + itemData.name + " in your inventory.");
        }
    }
}