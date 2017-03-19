using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {

    // Use this for initialization
    public GameObject Map;
    public GameObject Inventory;
    public GameObject PlayerInv;
    public GameObject BoxInv;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    
    public void OpenMap()
    {
      //  Debug.Log("Active "+ Map.activeInHierarchy);
        if (!Map.activeInHierarchy)
        {
            Map.SetActive(true);
            Global.OpenUI = true;
        }
        else
        {
            Map.SetActive(false);
            Global.OpenUI = false;
        }
    }
    public void OpenInventory()
    {
       // Debug.Log("Active " + Map.activeInHierarchy);
        if (!Inventory.activeInHierarchy)
        {
            BoxInv.SetActive(false);
            Inventory.SetActive(true);
            Global.OpenUI = true;
        }
        else
        {
            Inventory.SetActive(false);
            Global.OpenUI = false;
        }
    }
    public void OpenBox()
    {
        // Debug.Log("Active " + Map.activeInHierarchy);
        if (!Inventory.activeInHierarchy)
        {
            BoxInv.SetActive(true);
            Inventory.SetActive(true);
            Global.OpenUI = true;
        }
        else
        {
            BoxInv.SetActive(false);
            Inventory.SetActive(false);
            Global.OpenUI = false;
        }
    }
}
