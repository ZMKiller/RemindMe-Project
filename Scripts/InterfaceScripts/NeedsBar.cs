using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NeedsBar : MonoBehaviour {

    // Use this for initialization
    public GameObject HealthBar;
    public GameObject FoodBar;
    public GameObject EnergyBar;

    public GameObject Str;
    public GameObject Vit;
    public GameObject Agi;
    public GameObject Int;

    public GameObject Strbar;
    public GameObject Vitbar;
    public GameObject Agibar;
    public GameObject Intbar;

    public Text StrTxt;
    public Text VitTxt;
    public Text AgiTxt;
    public Text IntTxt;

    float HealthBarLenght = 1;
    float FoodBarLenght = 1;
    float EnergyBarLenght = 1;
    public float speedDropHealth = 0;
    public float speedDropFood = -0.0004f;
    public float speedDropEnergy = -0.0001f;
     void Awake()
    {
        Strbar = Str.transform.FindChild("bar").gameObject;
        Vitbar = Vit.transform.FindChild("bar").gameObject;
        Agibar = Agi.transform.FindChild("bar").gameObject;
        Intbar = Int.transform.FindChild("bar").gameObject;

        StrTxt = Str.transform.FindChild("Text").gameObject.GetComponent<Text>();
        VitTxt = Vit.transform.FindChild("Text").gameObject.GetComponent<Text>();
        AgiTxt = Agi.transform.FindChild("Text").gameObject.GetComponent<Text>();
        IntTxt = Int.transform.FindChild("Text").gameObject.GetComponent<Text>();
    }
    void Start () {
        

        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ChangeHealth(float f)
    {
        HealthBarLenght += f;
        if (HealthBarLenght < 0)
            HealthBarLenght = 0;
        if (HealthBarLenght > 1)
            HealthBarLenght = 1;
        ChangeBar();
    }
    public void ChangeFood(float f)
    {
        FoodBarLenght += f;
        if (FoodBarLenght < 0)
            FoodBarLenght = 0;
        if (FoodBarLenght > 1)
            FoodBarLenght = 1;
        ChangeBar();
    }
    public void ChangeEnergy(float f)
    {
        EnergyBarLenght += f;
        if (EnergyBarLenght < 0)
            EnergyBarLenght = 0;
        if (EnergyBarLenght > 1)
            EnergyBarLenght = 1;
        ChangeBar();
    }
    public void ChangeBar()
    {
        HealthBar.GetComponent<RectTransform>().localScale = new Vector3(HealthBarLenght, 1);
        FoodBar.GetComponent<RectTransform>().localScale = new Vector3(FoodBarLenght, 1);
        EnergyBar.GetComponent<RectTransform>().localScale = new Vector3(EnergyBarLenght, 1);
       // Debug.Log(HealthBarLenght);
    }
    public void ChangeStats(int str,int vit,int agi,int Int)
    {
        StrTxt.text = str.ToString();
        VitTxt.text = vit.ToString();
        AgiTxt.text = agi.ToString();
        IntTxt.text = Int.ToString();
    }
}
