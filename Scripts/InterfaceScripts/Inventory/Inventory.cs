using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory
{

    Dictionary<int, Item> inventory;

   public Inventory()
    {
       
        inventory = new Dictionary<int, Item>();
    }
    public Inventory(Dictionary<int, Item> _inventory)
    {
        inventory = _inventory;
    }

    public void AddItem(Item item)
    {
        int id = 0;
        while(inventory.ContainsKey(id))
        {
            ++id;
        }
        
        inventory.Add(id, item);
    }
    public void RemoveItem(int key)
    {
        if(inventory.ContainsKey(key))
        {
            inventory.Remove(key);
        }
        
    }
    public bool ConteinsItem(int id)
    {
     return   inventory.ContainsKey(id);
    }
    public Item GetItem(int id)
    {
        if(ConteinsItem(id))
        {
            return inventory[id];
        }
        else
        {
            return null;
        }
    }
    public void AddItemInSlot(Item item, int id)
    {
        if(!inventory.ContainsKey(id))
        {
            inventory.Add(id, item);
        }
    }
    public int returncount()
    {
        return inventory.Count;
    }
}