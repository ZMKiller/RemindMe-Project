using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Outline : MonoBehaviour

{
    bool isOutline = false;

    void Start () {
      //  Debug.Log(gameObject.GetComponent<Image>().sprite.name);
	}
	
	// Update is called once per frame
	void Update () {
       
    }
    

    public void Click()
    {
        if (!isOutline)
        {
           
            isOutline = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Room0/Location/" + gameObject.GetComponent<SpriteRenderer>().sprite.name + "_out");
            return;
        }
        
    }
    
    public bool Checkoutline()
    {
        return isOutline;
    }
    public void End()
    {
        if (isOutline)
        {
            isOutline = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Room0/Location/" + gameObject.GetComponent<SpriteRenderer>().sprite.name.Substring(0, gameObject.GetComponent<SpriteRenderer>().sprite.name.Length - 4));
            return;
        }
    }
}
