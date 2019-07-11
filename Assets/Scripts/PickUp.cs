using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : Interactable {

    public Item item;

    public override void Interact()
    {
        base.Interact();

        var result = InventoryManager.Instance.AddItem(item);
        if (result)
        {
            Debug.Log("Picking up item " + item.name);

            // put the item in the inventory
            Destroy(gameObject);
        }
    }
}
