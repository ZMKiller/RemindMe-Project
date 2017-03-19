using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDamage : MonoBehaviour {

    // Use this for initialization
    float speed;
    Vector2 vector;
    float gravityX;
    float gravityY;
    float timelife;
    

	void Start () {
        float x = Global.Grand.Next(30,70);
        x /= 100;
        int xm = Global.Grand.Next(0, 2);
        if(xm==0)
        {
            x = -x;
            
        }
        float y = Global.Grand.Next(30, 70);
        y /= 100;
        
        
        speed = Global.Grand.Next(3, 4);
        vector = new Vector2(x*speed, y * speed);
        
        gravityX = 1;
        gravityY = 3;
        timelife = Global.Grand.Next(150, 200)/100;
    }
	
	// Update is called once per frame
	void Update () {
        textdamageUpdate();

    }
    public void textdamageUpdate()
    {
        timelife -= Time.deltaTime;
        if(timelife>0)
        {
            gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x+vector.x*Time.timeScale, gameObject.transform.localPosition.y + vector.y * Time.timeScale);
            if(vector.x>0)
            vector = new Vector2(vector.x- gravityX * Time.deltaTime, vector.y);
            if(vector.x<0)
            vector = new Vector2(vector.x + gravityX * Time.deltaTime, vector.y);
            gravityX -= 0.1f * Time.deltaTime;
            vector = new Vector2(vector.x , vector.y - gravityY * Time.deltaTime);
           
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
