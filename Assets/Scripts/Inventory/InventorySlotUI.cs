using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    private Item item;
    public TextMeshProUGUI itemText;

    public void AddItem(Item newItem)
    {
        item = newItem;
        itemText.text = item.name;
    }

    public void ClearItem()
    {
        item = null;
        itemText.text = "";
    }

    public void UseItem()
    {
        item.Use();
    }
}
