using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {

   public int ItemId;
    public string ItemName;
    public Color color;
   public string Sprite;
  public  Item()
    {
        ItemId = 1;
        ItemName = "test";
        color = new Color(1, 1, 0);
        Sprite = "Soap";
    }
   public Item(int id, string name, Color _color)
    {
        ItemId = id;
        ItemName = name;
        color = _color;
    }
}
