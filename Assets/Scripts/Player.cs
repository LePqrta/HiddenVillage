using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Player : MonoBehaviour
{
    public InventoryManager inventoryManager;
    private TileManager tileManager;
    private int coin;
    private int price=1;
    public GameObject text;

    public TextMeshProUGUI coinText;


    private void Start()
    {
        coin=2;
        tileManager = GameManager.instance.tileManager;
        text.SetActive(false);
    }

    private void Update()
    {
        coinText.text="Coins: "+coin.ToString();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (tileManager != null)
            {
                Vector3Int position = new Vector3Int((int)transform.position.x, (int)transform.position.y, 0);

                string tileName = tileManager.GetTileName(position);

                if (!string.IsNullOrWhiteSpace(tileName))
                {
                    if (tileName == "interactable" && inventoryManager.toolbar.selectedSlot.itemName == "Hoe")
                    {
                        tileManager.SetInteractedPlow(position);
                    }
                    if (tileName == "plowed tile" && inventoryManager.toolbar.selectedSlot.itemName.Contains("Seed")){
                        tileManager.SetInteractedSow(position);
                        inventoryManager.toolbar.selectedSlot.RemoveItem();
                        
                        Debug.Log("Can be sowed");
                    }
                    if(tileName == "harvestable tile"){
                        tileManager.HartvestTile(position);
                        coin+=2;
                    }
                    
                }
            }
        }
    }

    public void DropItem(Item item)
    {
        Vector2 spawnLocation = transform.position;
        Vector2 spawnOffset = Random.insideUnitCircle * 0.5f;

        Item droppedItem = Instantiate(item, spawnLocation + spawnOffset, Quaternion.identity);
        droppedItem.rb2d.AddForce(spawnOffset * .2f, ForceMode2D.Impulse);
    }

    public void DropItem(Item item, int numToDrop)
    {
        for (int i = 0; i < numToDrop; i++)
        {
            DropItem(item);
        }
    }
    public void Buy(){
        if(coin>=price){
            DropItem(tileManager.item);
            coin--;
        }
        else{
            text.SetActive(true);
        }
    }
}
