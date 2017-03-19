using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {

    // Use this for initialization
   
    GameObject PlayerObject;
   public GameObject Psprite;
    Animator animator;
    public GameObject MainCamera;
    public Outline target;
    bool start;
    float Mpos = 0;
    float speed = 5;
    float move = 0;
    float Last = 0;
    float Pstart = 0;
    bool finish = false;
   public bool fight = false;
    void Start () {
        PlayerObject = gameObject;
        animator = GetComponent<Animator>();
        start = false;
        
    }
	
	// Update is called once per frame
	void Update () {

        //if (Input.GetMouseButtonDown(0))
        //{
        //    RotatePlayer(Xmouse());
           
        //}
        MovePlayerToPos();
     
    }

   public void startMove(float x)
    {
        if (!fight)
        {
            RotatePlayer(Xmouse(x));
        }
    }
    public float Xmouse(float X)
    {
        
        
        if (X > PlayerObject.transform.localPosition.x)
        {
            move = speed;
        }
        if(X < PlayerObject.transform.localPosition.x)
        {
            move = -speed;
        }
        if (X > 6.8f)
            X = 6.8f;
        if (X < -6.8f)
            X = -6.8f;
        return X;
    }
    public void RotatePlayer(float x)
    {
      //  Debug.Log("X "+ Screen.width);
        if (x> PlayerObject.transform.localPosition.x)
        {
            //     Debug.Log("Player R " + PlayerObject.transform.localPosition.x);
            PlayerObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        }
         if(x< PlayerObject.transform.localPosition.x)
        {
            PlayerObject.transform.rotation = new Quaternion(0, 180, 0, 0);
      //      Debug.Log("Player L " + PlayerObject.transform.localPosition.x);
        }
     //   Debug.Log("Player N " + PlayerObject.transform.localPosition.x);
        start = true;
        Mpos = x;
        Pstart = PlayerObject.transform.localPosition.x;
        

    }
    public void MovePlayerToPos()
    {
        if (start)
        {
            Last = move * Time.deltaTime / 0.22f;
            if (Last < 0)
                Last = -Last;
            PlayerObject.transform.localPosition = new Vector3(PlayerObject.transform.localPosition.x+move*Time.deltaTime, PlayerObject.transform.localPosition.y, PlayerObject.transform.localPosition.z);
            animator.SetBool("Walk", true);
            if (PlayerObject.transform.localPosition.x >= Mpos - Last && PlayerObject.transform.localPosition.x <= Mpos + Last)
            {
                animator.SetBool("Walk", false);
            }
            if(PlayerObject.transform.localPosition.x> Pstart && PlayerObject.transform.localPosition.x> Mpos || PlayerObject.transform.localPosition.x < Pstart && PlayerObject.transform.localPosition.x < Mpos)
            {
                finish = true;
            }
                if (finish)
            {
                
                PlayerObject.transform.localPosition = new Vector3(Mpos, PlayerObject.transform.localPosition.y, PlayerObject.transform.localPosition.z);
                start = false;
                finish = false;
                try
                {
                    target.End();
                }
                catch (System.Exception)
                {

                    
                }
                ;
              //  Debug.Log("te");
              //   Debug.Log("PlayerMove " + PlayerObject.transform.localPosition.x);
              // Debug.Log("Mpos " + Mpos);

            }
            
        }
        
    }

    
}
