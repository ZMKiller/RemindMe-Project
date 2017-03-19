using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryCellScript : MonoBehaviour, IPointerClickHandler, IDragHandler, IEndDragHandler, IDropHandler
{

    // Use this for initialization
    public int CellId;
    public Player player;
    public void OnDrag(PointerEventData eventData)
    {
        
            if(player.checkItem(CellId,player.inventory))
            {
                player.StartDragItem(CellId,player.inventory,player.Cells);
            }
        
       
    }

    public void OnDrop(PointerEventData eventData)
    {

        if (player.CheckDrag())
        {
            player.EndDragItem(CellId, player.inventory, player.Cells);
        }

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
            if(player.CheckDrag())
            {
                player.EndDragItem(CellId, player.inventory, player.Cells);
            }
       
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //try
        //{
        //    GameObject.Find("InventoryTextMoney").GetComponent<Text>().text = CellId.ToString();
        //}
        //catch (Exception)
        //{

        //    throw new NotImplementedException();
        //}
    }

    

    void Start () {
       

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
