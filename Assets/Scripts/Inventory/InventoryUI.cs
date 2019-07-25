using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour {

    private InventorySlotUI[] slots;
    private InventoryManager inventory;

    private void Start()
    {
        inventory = InventoryManager.Instance;
        inventory.OnItemsChanged += OnItemsChanged;

        slots = GetComponentsInChildren<InventorySlotUI>();
    }

    private void OnItemsChanged()
    {
        for (var i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearItem();
            }
        }
    }
}
