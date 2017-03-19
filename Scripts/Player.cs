using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Person {

    // Use this for initialization
    public string CellSprite = "Interface/Inventory/Inv_cell";
    public GameObject Interface;
    public GameObject InventoryObject;
    public GameObject CellPrefab;
    public GameObject DragCell;
    Item DragItem;
    bool Draget = false;
    int StartDragid;
    public List<GameObject> Cells = new List<GameObject>();
    public List<GameObject> CellsEqwip = new List<GameObject>();
    public Inventory inventory;
   public int LenghtInventory = 5;
    public int HightInventory = 4;
    public float Otstyp = 5;
    int StatPoint;
    void Start () {
        Dictionary<int, Item> dc = new Dictionary<int, Item>();
        dc.Add(1,new Item());
        inventory = new Inventory(dc);
        CreateInventory();
        eqwip = new Inventory();
        countingStats();
        PF = new PersonFight(GetComponent<Animator>(), this.gameObject);
        NowFatigue = Fatigue;
        NowHealth = Health;
        Interface.GetComponent<NeedsBar>().ChangeStats(this.Strength,Vitality,Agility,this.Intellect);
        Name = "Player";
    }
	
	// Update is called once per frame
	void Update () {
		if(DragCell.activeInHierarchy)
        {
            DragCell.transform.position = Input.mousePosition;
        }
	}
    public void CreateInventory()
    {
        


     GameObject InvObj = InventoryObject.transform.FindChild("Inventory").gameObject;
        
        Vector3 startSpawn = InventoryObject.transform.FindChild("Inventory").FindChild("startspawn").localPosition;
        float x = startSpawn.x;
        float y = startSpawn.y;
        float otsX = CellPrefab.GetComponent<RectTransform>().rect.width;
        float otsY = CellPrefab.GetComponent<RectTransform>().rect.height;
        for (int i = 0; i < HightInventory; i++)
        {
            for (int z = 0; z < LenghtInventory; z++)
            {
                
              GameObject cell =  Instantiate(CellPrefab);
                
                cell.GetComponent<InventoryCellScript>().CellId = i * LenghtInventory + z;
                cell.GetComponent<InventoryCellScript>().player = this;
              if (  inventory.ConteinsItem(cell.GetComponent<InventoryCellScript>().CellId))
                {
                  Item itm=  inventory.GetItem(cell.GetComponent<InventoryCellScript>().CellId);
                    cell.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Items/" + itm.Sprite);
                }
                else
                {
                    cell.transform.GetChild(0).gameObject.SetActive(false);
                }
                Cells.Add(cell);
                cell.transform.SetParent(InvObj.transform);
                cell.transform.localScale = new Vector3(1, 1, 1);
                cell.transform.localPosition = new Vector3(x, y, 0);
                x += otsX+Otstyp;
            }
            y -= (otsY + Otstyp);
            x = startSpawn.x;
        }
        for (int i = 0; i < CellsEqwip.Count; i++)
        {
            CellsEqwip[i].GetComponent<EqwipCellScript>().player = this;
        }
    }
    public bool checkItem (int id,Inventory inv)
    {
      return inv.ConteinsItem(id);
    }
    public void StartDragItem(int id, Inventory inv, List<GameObject> cell)
    {
        if(inv.ConteinsItem(id))
        {
            StartDragid = id;
            DragItem = inv.GetItem(id);
            DragCell.GetComponent<Image>().sprite = Resources.Load<Sprite>("Items/"+inv.GetItem(id).Sprite);
            //cell[id].GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>(CellSprite);
            cell[id].transform.GetChild(0).gameObject.SetActive(false);
            inv.RemoveItem(id);
            
            DragCell.SetActive(true);
            Draget = true;
        }
    }
    public void EndDragItem(int id, Inventory inv, List<GameObject> cell)
    {
        if (!inv.ConteinsItem(id) )
        {
            inv.AddItemInSlot(DragItem,id);
            DragCell.GetComponent<Image>().sprite = Resources.Load<Sprite>(CellSprite);
            cell[id].transform.GetChild(0).gameObject.SetActive(true);
            cell[id].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Items/" + inv.GetItem(id).Sprite);
            DragItem = null;
        }
        else if (inv.ConteinsItem(id) )
        {
            inv.AddItemInSlot(DragItem,StartDragid);
            DragCell.GetComponent<Image>().sprite = Resources.Load<Sprite>(CellSprite);
            cell[StartDragid].transform.GetChild(0).gameObject.SetActive(true);
            cell[StartDragid].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Items/" + inv.GetItem(id).Sprite);
            DragItem = null;
        }
       
        DragCell.SetActive(false);
        Draget = false;
    }
    public bool CheckDrag()
    {
        return Draget;
    }
}
