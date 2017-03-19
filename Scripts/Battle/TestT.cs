using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestT : MonoBehaviour {


    // Use this for initialization
   public GameObject txt;
    public GameObject parent;
    
    
    void Start()
    {
       
        
    }

    // Update is called once per frame
    
    public void SpawnDamage(int damage, Color cl)
    {
        Vector3 pr = Camera.main.WorldToScreenPoint(parent.transform.position);
        transform.localPosition = new Vector3(pr.x-Screen.width/2, pr.y-Screen.height/2);
        GameObject gm = Instantiate(txt);
        
        gm.transform.SetParent(gameObject.transform);
        gm.transform.localPosition = new Vector3(0, 0, 0);
        gm.GetComponent<Text>().text = "-" + damage + "hp";
        gm.GetComponent<Text>().color = cl;
    }
    public void SpawnEnergy(int energy, Color cl)
    {
        Vector3 pr = Camera.main.WorldToScreenPoint(parent.transform.position);
        transform.localPosition = new Vector3(pr.x - Screen.width / 2, pr.y - Screen.height / 2);
        GameObject gm = Instantiate(txt);

        gm.transform.SetParent(gameObject.transform);
        gm.transform.localPosition = new Vector3(0, 0, 0);
        gm.GetComponent<Text>().text = "+" + energy + " energy";
        gm.GetComponent<Text>().color = cl;
    }
}
