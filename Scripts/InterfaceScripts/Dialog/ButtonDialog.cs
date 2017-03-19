using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonDialog : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler {
   
    public string name = "Vibor";
  
    public void OnPointerEnter(PointerEventData eventData)
    {
        entermouse();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        exitmouse();
    }

    public void ClickDialogSay()
    {
        Camera.main.gameObject.GetComponent<CreateDialog>().create();
        end();
    }
    public void ClickDialogTrade()
    {
        Global.OpenUI = false;
        end();
    }
    public void ClickDialogFight()
    {
        Camera.main.gameObject.GetComponent<Fight>().StartBattleClick();
        end();
    }
    public void ClickDialogQuest()
    {
        Global.OpenUI = false;
        end();
    }
    public void end()
    {
        
        exitmouse();
        
        transform.parent.transform.parent.gameObject.SetActive(false);
        
    }

    public void entermouse()
    {
        gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Interface/Dialog/" + name + "_active");
    }
    public void exitmouse()
    {
        gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Interface/Dialog/" + name);
    }

    
}
