using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public Text nameText;
    public Text costText;

    public void SetItemData(GameMarket.ItemData itemData)
    {
        nameText.text = itemData.name;
        costText.text = "Cost: " + itemData.cost.ToString();
    }
}