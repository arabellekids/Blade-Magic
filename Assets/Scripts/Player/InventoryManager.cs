using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

    #region Singleton
    private static InventoryManager instance;
    public static InventoryManager Instance
    {
        get
        {
            return instance;
        }
    }

    public void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Multiple instances of " + name + " detected!");
        }
        instance = this;
    }
    #endregion

    public GameObject inventoryCanvas;
    public AudioSource inventorySound;
    public int capacity = 20;
    public List<Item> items = new List<Item>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryCanvas.SetActive(!inventoryCanvas.activeInHierarchy);
            inventorySound.Play();
        }
    }
    public bool AddItem(Item item)
    {
        if (items.Count >= capacity)
        {
            Debug.Log("Bags are full!");
            return false;
        }

        items.Add(item);

        if (OnItemsChanged != null)
        {
            OnItemsChanged.Invoke();
        }
        return true;
    }

    public void RemoveItem(Item item)
    {
        var result = items.Remove(item);
        if (!result)
        {
            Debug.LogError("Item " + item.name + " was not found in inventory.");
            return;
        }

        if (OnItemsChanged != null)
        {
            OnItemsChanged.Invoke();
        }
    }

    public event System.Action OnItemsChanged;
}

