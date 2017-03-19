using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ViborDialog : MonoBehaviour,IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler {

    // Use this for initialization
    public string text = "";
    public int id = -1;
    public string sprite = "Vibor";
    public string sprite_active = "Vibor_active";
    public void OnPointerClick(PointerEventData eventData)
    {
        click();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Interface/Dialog/"+ sprite_active);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Interface/Dialog/" + sprite);
    }

    void Start () {
        GetComponentInChildren<Text>().text = text;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void click()
    {
        Camera.main.gameObject.GetComponent<CreateDialog>().SelectOtvet(id);
    }
}
