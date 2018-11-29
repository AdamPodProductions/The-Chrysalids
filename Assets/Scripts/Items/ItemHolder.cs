using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : MonoBehaviour
{
    public Item item;

    public void UseItem()
    {
        FindObjectOfType<Items>().UseItem(this);
    }
}
