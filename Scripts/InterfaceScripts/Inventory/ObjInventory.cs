using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjInventory : MonoBehaviour {

    // Use this for initialization

    Inventory inv = new Inventory();
    public int CountItems;
    public int lenght;
    public int height;
    void Start () {
        
        CreateItems();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void CreateItems()
    {

        for (int i = 0; i < CountItems; i++)
        {
            inv.AddItem(new Item());
        }
        
    }
    public Inventory GetInventory()
    {
        return inv;
    }
}
