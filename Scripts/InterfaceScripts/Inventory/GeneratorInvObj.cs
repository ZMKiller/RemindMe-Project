using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneratorInvObj : MonoBehaviour {

    // Use this for initialization
    public GameObject Parrent;
    public GameObject startPoss;
    public GameObject objcell;
    int invLenght = 3;
    int invHeight = 3;
    float Otstyp = 5;
    public Player player;
    public List<GameObject> Cells = new List<GameObject>();
    Inventory inv;
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OpenBox(Inventory _inv, int height,int lenght)
    {
        inv = _inv;
        invHeight = height;
        invLenght = lenght;
        DeleteCells();
        GenerateCells();
    }
    public void DeleteCells()
    {
        if(Cells.Count>0)
        {
            for (int i = 0; i < Cells.Count; i++)
            {
                Destroy(Cells[i]);
            }
            Cells.Clear();
        }

    }
    public void GenerateCells()
    {
        Vector3 startSpawn = startPoss.transform.localPosition;
        float x = startSpawn.x;
        float y = startSpawn.y;
        float otsX = objcell.GetComponent<RectTransform>().rect.width;
        float otsY = objcell.GetComponent<RectTransform>().rect.height;
        for (int i = 0; i < invHeight; i++)
        {
            for (int z = 0; z < invLenght; z++)
            {

                GameObject cell = Instantiate(objcell);

                cell.GetComponent<ObjCell>().CellId = i * invLenght + z;
                cell.GetComponent<ObjCell>().obj = inv;
                cell.GetComponent<ObjCell>().gio = this;
                if (inv.ConteinsItem(cell.GetComponent<ObjCell>().CellId))
                {
                    Item itm = inv.GetItem(cell.GetComponent<ObjCell>().CellId);
                    cell.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Items/" + itm.Sprite);
                }
                else
                {
                    cell.transform.GetChild(0).gameObject.SetActive(false);
                }
                Cells.Add(cell);
                cell.transform.SetParent(Parrent.transform);
                cell.transform.localScale = new Vector3(1, 1, 1);
                cell.transform.localPosition = new Vector3(x, y, 0);
                x += otsX + Otstyp;
            }
            y -= (otsY + Otstyp);
            x = startSpawn.x;
        }
    }
}
