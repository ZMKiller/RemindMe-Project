using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickedItems : MonoBehaviour
{
    public float HeightCamera = 1080;
    public float WidthCamera = 1920;
    float HeightNow = 0;
    float WidthNow = 0;
    float Mod = 0;
    float ModT = 0;
    float res = 0;
    public float PixelToUnit = 100;
    public GameObject DialogPanel;
    public GameObject DialogFon;
    
    public GameObject Dialog;
    public GameObject Vibor;

   public GameObject Player;
    MovePlayer player;
    Vector3 pointCreateDialog;
    //void OnMouseDown()
    //{
    //    if (!Global.OpenUI)
    //    {
    //        float X = MainCamera.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition).x;
    //        foreach (var pl in Player)
    //        {
    //          pl.GetComponent<MovePlayer>().startMove(X);
    //        }
            
    //    }
    //}

        // Use this for initialization
        void Start () {
        Mod = (float)1920 / (float)1080;
        ModT = (float)Screen.width / (float)Screen.height;
        res = Mod / ModT;
        Debug.Log("Mod " + Mod);
        Debug.Log("ModT " + ModT);
        Debug.Log("res " + res);
        Camera.main.orthographicSize = Camera.main.orthographicSize* res;
        Player = GameObject.FindGameObjectWithTag("Player");
        player = Player.GetComponent<MovePlayer>();
    }
	
	// Update is called once per frame
	void Update () {

        CheckClick();
    }
    public Vector3 getPlayerDialogStartPos()
    {
        RectTransform objectRectTransform = GameObject.Find("Canvas").GetComponent<RectTransform>();
       
        float mod = objectRectTransform.rect.height / (float)Screen.height;
        
      Vector3 v= Camera.main.WorldToScreenPoint(pointCreateDialog);
       // Debug.Log("V " + v);
      Vector3 pos  = new Vector3((v.x - Screen.width / 2)* mod, (v.y - Screen.height / 2)* mod);
        Debug.Log("pos " + pos);
        return pos;
    }
    public void CheckClick()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !Global.OpenUI)
        {
            Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 point2d = new Vector2(point.x, point.y);
            RaycastHit2D raycast2d = Physics2D.Raycast(point2d, point2d);
           // Debug.Log(raycast2d.collider.transform.name);
            
                if (raycast2d.transform.tag == "Fon")
                {

                    player.startMove(raycast2d.point.x);
                    try
                    {
                        player.target.GetComponent<Outline>().End();
                    }
                    catch (Exception)
                    {


                    }
                }
                if(raycast2d.transform.tag == "ItemBox")
            {
                ObjInventory objinv = raycast2d.transform.gameObject.GetComponent<ObjInventory>();
                GetComponent<GeneratorInvObj>().OpenBox(objinv.GetInventory(), objinv.height, objinv.lenght);
                GameObject.Find("Canvas").GetComponent<ButtonScript>().OpenBox();
            }
                if (raycast2d.transform.tag == "GameItem")
                {

                    player.startMove(raycast2d.transform.position.x);

                    if (player.target != raycast2d.transform.gameObject.GetComponent<Outline>())
                    {
                        try
                        {
                            player.target.GetComponent<Outline>().End();
                        }
                        catch (Exception)
                        {


                        }
                        player.target = raycast2d.transform.gameObject.GetComponent<Outline>();
                        raycast2d.transform.gameObject.GetComponent<Outline>().Click();
                    }
                    else if (!raycast2d.transform.gameObject.GetComponent<Outline>().Checkoutline())
                    {
                        raycast2d.transform.gameObject.GetComponent<Outline>().Click();
                    }
                }
                if(raycast2d.transform.tag == "PersonItem")
            {
                // GetComponent<Fight>().StartBattleClick();
                GetComponent<CreateDialog>().destroyDialog();
                GetComponent<CreateDialog>().SetName(raycast2d.transform.gameObject.GetComponent<Person>().NameDialog);
                RectTransform objectRectTransform = GameObject.Find("Canvas").GetComponent<RectTransform>();

                float mod = objectRectTransform.rect.height / (float)Screen.height;
                Vector3 pr = Camera.main.WorldToScreenPoint(raycast2d.transform.Find("DialogPoit").transform.position);
                DialogPanel.transform.localPosition = new Vector3((pr.x - Screen.width / 2)* mod, (pr.y - Screen.height / 2)* mod);
                DialogFon.SetActive(true);
                DialogPanel.SetActive(true);
                // DialogPanel.GetComponentsInChildren<ButtonDialog>()[0];
                pointCreateDialog = raycast2d.transform.Find("Head").transform.position;
                Global.OpenUI = true;
            }
            
        }
    }
}
