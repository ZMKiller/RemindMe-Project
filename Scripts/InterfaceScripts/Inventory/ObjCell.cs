using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjCell : MonoBehaviour, IPointerClickHandler, IDragHandler, IEndDragHandler, IDropHandler
{

    // Use this for initialization

    public int CellId;
    public Player player;
    public Inventory obj;
   public GeneratorInvObj gio;
    public void OnDrag(PointerEventData eventData)
    {

        if (player.checkItem(CellId, obj))
        {
            player.StartDragItem(CellId, obj, gio.Cells);
        }


    }

    public void OnDrop(PointerEventData eventData)
    {

        if (player.CheckDrag())
        {
            player.EndDragItem(CellId, obj, gio.Cells);
        }

    }

    public void OnEndDrag(PointerEventData eventData)
    {

        if (player.CheckDrag())
        {
            player.EndDragItem(CellId, obj, gio.Cells);
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
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
