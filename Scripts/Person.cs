using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class Person : MonoBehaviour
{

    public string NameDialog;
    List<Dialog> listD;
    public bool IsDialog = false;
    public Inventory eqwip;
    public PersonFight PF;
    public GameObject SpawnDamge;

   public GameObject barhp;
    public GameObject barenergy;
    public Text texthp;
    public Text textenergy;

    public Vector3 StartPos;
    public Quaternion StartRotation;
    public int Lvl;
    public bool Death=false;

    public string Name;
    public int Strength;   
    public int Agility;
    public int Vitality;
    public int Intellect;

    public int BonusStrength;
    public int BonusAgility;
    public int BonusVitality;
    public int BonusIntellect;

    public int Health;
    public int Fatigue;
    public int NowHealth;
    public int NowFatigue;

    public int Defence;
    public int Evasion;
    public int Attack;  
    public int Damage;
    public int Initiative;

    public int BonusHealth = 0;
    public int BonusFatigue = 0;
    public int BonusDefence=0;
    public int BonusEvasion=0;
    public int BonusAttack=0;
    public int BonusDamage=0;

    public int PersonMoney;
    public List<PersonSkill> MoveAttacks= new List<PersonSkill>() { new PersonSkill("punch", 5, 0.3f, 1.1f), new PersonSkill("doublepunch", 10, 0.35f, 1.7f) };
    public List<PersonSkill> MoveDefence = new List<PersonSkill>() { new PersonSkill("getpunch", 0, 0.3f, 0), new PersonSkill("getdoublepunch", 0, 0.35f, 0) };
     void countingStrenght()
    {
        Damage += Strength * 3;
        Defence += Strength * 1;
        Attack += Strength * 1;
        Initiative += Strength* 1;
    }
    void countingAgility()
    {
        Attack += Agility * 3;
        Evasion += Agility * 2;
        Initiative += Agility * 2;
    }
    void countingVitality()
    {
        
        Health += Vitality * 8;
        Fatigue += Vitality * 8;
        Defence += Vitality*2;
        Initiative += Agility * 1;
    }
    void countingIntellect()
    {
        Initiative +=Intellect* 2;

    }
    public void countingStats()
    {
        Health = BonusHealth;
        Fatigue = BonusFatigue;
        Defence = BonusDefence;
        Evasion = BonusEvasion;
        Attack = BonusAttack; 
        Damage = BonusDamage;
        Initiative = Lvl * 2;

        countingStrenght();
        countingAgility();
        countingVitality();
        countingIntellect();
    }
    public void getHpBar()
    {
        float OneProcent = (float)Health /100;
        float scale = 1 - ((float)((Health - NowHealth) / OneProcent) / 100);
        Debug.Log("scale " + scale);
        Debug.Log("hp " +100/ Health);
        if (NowHealth <= 0)
        {
            barhp.transform.localScale = new Vector3(0, 1);
        }
        else
        {
            barhp.transform.localScale = new Vector3(scale, 1);
        }
        
    }
    public void getEnergyBar()
    {
        float OneProcent = (float)Fatigue /100;
        float scale = 1 - ((float)((Fatigue - NowFatigue) / OneProcent) / 100);
        Debug.Log("scale "+scale);
        if (NowFatigue <= 0)
        {
            barenergy.transform.localScale = new Vector3(0, 1);
        }
        else
        {
           barenergy.transform.localScale = new Vector3(scale, 1);
        }
        
    }
    public void getTextHp()
    {
        texthp.text =  NowHealth + "/" + Health;
    }
    public void getTextEnergy()
    {
        textenergy.text = NowFatigue + "/" + Fatigue;
    }
    

    
    void Start()
    {
        listD = new List<Dialog>();
        countingStats();
        PF = new PersonFight(GetComponent<Animator>(), this.gameObject);
        NowFatigue = Fatigue;
        NowHealth = Health;
        Name = "Enemy";
    }
}
