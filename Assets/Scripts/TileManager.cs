using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    public Tilemap interactableMap;
    public Tilemap collidableMap;
    public Tile hiddenInteractableTile;
    public Tile plowedTile;
    public Tile sowedTile;
    public Tile harvastableTile;
    public Item item;
    public int growTime;

    void Start()
    {
        foreach (var position in interactableMap.cellBounds.allPositionsWithin)
        {
            TileBase tile = interactableMap.GetTile(position);

            if (tile != null && tile.name == "interactable_visible")
            {
                interactableMap.SetTile(position, hiddenInteractableTile);
            }
        }
    }

    public void SetInteractedPlow(Vector3Int position)
    {
        Debug.Log(GetTileName(position));
        interactableMap.SetTile(position, plowedTile);
        plowedTile.name = "plowed tile";
        Debug.Log(GetTileName(position));
        
    }
    public void SetInteractedSow(Vector3Int position)
    {
        Debug.Log(GetTileName(position));
        interactableMap.SetTile(position, sowedTile);
        sowedTile.name = "sowed tile";
        Debug.Log(GetTileName(position));
        StartCoroutine(GrowPlant(position));
    }
    public void HartvestTile(Vector3Int position){
        interactableMap.SetTile(position, hiddenInteractableTile);
        DropItem(item,2);
    
    }

    public string GetTileName(Vector3Int position)
    {
        if (interactableMap != null)
        {
            TileBase tile = interactableMap.GetTile(position);

            if (tile != null)
            {
                return tile.name;
            }
        }

        return "";
    }
    private IEnumerator GrowPlant(Vector3Int position)
{
    // Wait for 10 seconds
    yield return new WaitForSeconds(growTime);

    // Change the tile to the harvestable tile
    interactableMap.SetTile(position, harvastableTile);
    harvastableTile.name = "harvestable tile";
    Debug.Log(GetTileName(position));
}
    public void DropItem(Item item)
    {
        Vector2 spawnLocation = transform.position;
        Vector2 spawnOffset = Random.insideUnitCircle * 1.25f;

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
}
