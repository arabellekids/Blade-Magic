using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName = "Item/Item", order =0)]
public class Item : ScriptableObject {

    public new string name;
    public Sprite sprite;

    public virtual void Use()
    {
        Debug.Log("Using "+name);
    }
}
