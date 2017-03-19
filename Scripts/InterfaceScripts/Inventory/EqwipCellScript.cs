using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EqwipCellScript : MonoBehaviour, IPointerClickHandler, IDragHandler, IEndDragHandler, IDropHandler
{

    public int CellId;
    public Player player;
    public void OnDrag(PointerEventData eventData)
    {

        if (player.checkItem(CellId, player.eqwip))
        {
            player.StartDragItem(CellId,player.eqwip, player.CellsEqwip);
        }


    }

    public void OnDrop(PointerEventData eventData)
    {

        if (player.CheckDrag())
        {
            player.EndDragItem(CellId, player.eqwip, player.CellsEqwip);
        }

    }

    public void OnEndDrag(PointerEventData eventData)
    {

        if (player.CheckDrag())
        {
            player.EndDragItem(CellId, player.eqwip, player.CellsEqwip);
        }


    }

    public void OnPointerClick(PointerEventData eventData)
    {
        try
        {
            GameObject.Find("InventoryTextMoney").GetComponent<Text>().text = CellId.ToString();
        }
        catch (Exception)
        {

            throw new NotImplementedException();
        }
    }



    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }
}
