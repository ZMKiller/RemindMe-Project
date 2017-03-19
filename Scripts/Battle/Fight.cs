using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fight : MonoBehaviour {

    // Use this for initialization
    List<int> DeleteVD;
    public List<ViewDamage> VD;
    public GameObject SpawnDamage;
    public List<GameObject> EnemyFighersObj;
    public GameObject PlayerObj;
    public Person player;
    public Person enemy;
    public float time;   
    bool Playermove = false;
int rand;

    public GameObject PlayingPanel;
    public GameObject FightPanel;
    public GameObject PlayerFightMenu;
    public GameObject EnemyFightMenu;
    public GameObject RoundFightMenu;

    
    public bool IsFighting = false;
    
    System.Random  r = new System.Random();
    float second = 0;

   
	void Start () {
        time = 999;
        player = PlayerObj.GetComponent<Player>();
        enemy = EnemyFighersObj[0].GetComponent<Person>();
        
        VD = new List<ViewDamage>();
        DeleteVD = new List<int>();
        GameObject gm = Instantiate(SpawnDamage);
        gm.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
        player.SpawnDamge = gm;
        gm.GetComponent<TestT>().parent = player.transform.FindChild("Head").gameObject;

        GameObject gm2 = Instantiate(SpawnDamage);
        gm2.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
        enemy.SpawnDamge = gm2;
        gm2.GetComponent<TestT>().parent = enemy.transform.FindChild("Head").gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        figtUpdate();


    }
    public void StartBattleClick()
    {
        if (PlayerObj.GetComponent<MovePlayer>().fight)
        {
            Endbattle();
        }
        else
        {
            StartFighting();
        }
    }
    public void figtUpdate()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (PlayerObj.GetComponent<MovePlayer>().fight)
            {
                Endbattle();
            }
            else
            {
                StartFighting();
            }
        }

        if (!IsFighting) return;

        second += Time.deltaTime;
        if (second >= 1)
        {
            second -= 1;
            ChangeTime();
            addEnergy();
        }
        
        
            time -= Time.deltaTime;
            StartStep();
            if (VD.Count > 0)
            {
                CheckDmg();
            }             
    }
    public void ChangeTime()
    {
        RoundFightMenu.transform.Find("Text").GetComponent<Text>().text = ((int)time).ToString();
    }
    public void addEnergy()
    {
        if (player.NowFatigue <= player.Fatigue - 2)
        {
            player.NowFatigue += 2;
            player.SpawnDamge.GetComponent<TestT>().SpawnEnergy(2, Color.yellow);
            player.getTextEnergy();
            player.getEnergyBar();
        }
        if (enemy.NowFatigue <= enemy.Fatigue - 2)
        {
            enemy.NowFatigue += 2;
            enemy.SpawnDamge.GetComponent<TestT>().SpawnEnergy(2, Color.yellow);
            enemy.getTextEnergy();
            enemy.getEnergyBar();
        }
    }
    public void StartStep()
    {
        if(CheckEndStep())
        {
           
               rand = r.Next(0, player.Initiative + enemy.Initiative + 1);
           // Debug.Log(rand);
           if (rand<= player.Initiative)
            {
                Playermove = true;
                Attack(player, enemy);
            }
            else
            {
                Playermove = false;
                Attack(enemy, player);
            }
            
        }
        
    }
    public void Attack(Person attack, Person defend)
    {
        int i = 0;
        List<int> mas = new List<int>();
        foreach (var item in player.MoveAttacks)
        {
            if (item.energyCost <= attack.NowFatigue)
            {
                mas.Add(i);

            }
            i++;
        }
        if (mas.Count == 0)
        {
            return;
        }
        else
        {
            i = r.Next(0, mas.Count);


            attack.PF.StarAttack(attack.MoveAttacks[mas[i]].SkillName);
            attack.NowFatigue -= attack.MoveAttacks[mas[i]].energyCost;
            Debug.Log("fatigure "+attack.MoveAttacks[mas[i]].energyCost+" "+ attack.MoveDefence[mas[i]].SkillName);
            defend.PF.StarAttack(defend.MoveDefence[mas[i]].SkillName);
            int dmg = (int)(attack.Damage*attack.MoveAttacks[mas[i]].modifyDmg) - defend.Defence;
            if (dmg <= 0)
                dmg = 1;
            VD.Add(new ViewDamage(attack.MoveAttacks[mas[i]].Time, defend.SpawnDamge.gameObject, dmg,defend));

        }
        
    }
    
    
    public void StartFighting()
    {
        Global.OpenUI = true;
        player.StartPos = PlayerObj.transform.position;
        player.StartRotation = PlayerObj.transform.rotation;
        player.NowHealth = player.Health;
        player.NowFatigue = player.Fatigue;

        enemy.StartPos = EnemyFighersObj[0].transform.position;
        enemy.StartRotation = EnemyFighersObj[0].transform.rotation;
        enemy.NowHealth = enemy.Health;
        enemy.NowFatigue = enemy.Fatigue;

        PlayerObj.transform.position = new Vector3(-1, -1,5);
        PlayerObj.transform.rotation = new Quaternion(0, 0,0,0);
        EnemyFighersObj[0].transform.position = new Vector3(1, -1, 5);
        EnemyFighersObj[0].transform.rotation = new Quaternion(0, 180, 0,0);
        player.PF.startFight();
        enemy.PF.startFight();
        PlayerObj.GetComponent<MovePlayer>().fight = true;
        IsFighting = true;
        PlayingPanel.SetActive(false);
        FightPanel.SetActive(true);
        SetBars();
    }
    public void Endbattle()
    {
        Global.OpenUI = false;
        player.PF.endFight();
        enemy.PF.endFight();
        PlayerObj.GetComponent<MovePlayer>().fight = false;
        IsFighting = false;
        FightPanel.SetActive(false);
        PlayingPanel.SetActive(true);
        PlayerObj.transform.position = player.StartPos;
        PlayerObj.transform.rotation = player.StartRotation;
        EnemyFighersObj[0].transform.position = enemy.StartPos;
        EnemyFighersObj[0].transform.rotation = enemy.StartRotation;
        VD.Clear();
    }
    public void SetBars()
    {
        PlayerFightMenu.transform.Find("NameImg").Find("TextName").gameObject.GetComponent<Text>().text = player.Name;;
        player.barhp = PlayerFightMenu.transform.Find("BackHealthBar").Find("HealthBar").gameObject;
        player.texthp = PlayerFightMenu.transform.Find("BackHealthBar").Find("TextHealth").gameObject.GetComponent<Text>();
        player.barenergy = PlayerFightMenu.transform.Find("BackEnergyBar").Find("EnergyBar").gameObject;
        player.textenergy = PlayerFightMenu.transform.Find("BackEnergyBar").Find("TextEnergy").gameObject.GetComponent<Text>();
        

        EnemyFightMenu.transform.Find("NameImg").Find("TextName").gameObject.GetComponent<Text>().text = enemy.Name;;
        enemy.barhp =      EnemyFightMenu.transform.Find("BackHealthBar").Find("HealthBar").gameObject;
        enemy.texthp =     EnemyFightMenu.transform.Find("BackHealthBar").Find("TextHealth").gameObject.GetComponent<Text>();
        enemy.barenergy =  EnemyFightMenu.transform.Find("BackEnergyBar").Find("EnergyBar").gameObject;
        enemy.textenergy = EnemyFightMenu.transform.Find("BackEnergyBar").Find("TextEnergy").gameObject.GetComponent<Text>();

        player.getHpBar();
        player.getEnergyBar();
        player.getTextHp();
        player.getTextEnergy();

       enemy.getHpBar();
       enemy.getEnergyBar();
       enemy.getTextHp();
       enemy.getTextEnergy();

    }
    public bool CheckEndStep()
    {
        if (enemy.PF.GetNowClipName() == "FightPos" && player.PF.GetNowClipName() == "FightPos")
        {
            Debug.Log("FightPos");
            return true;
        }
        else
            return false;
    }
    public void CheckDmg()
    {
        int max = VD.Count;
        int count = 0;
        while(count!=max)
        for (int i = 0; i < max; i++)
        {
            VD[i].TimeLeft -= Time.deltaTime;
            if(VD[i].TimeLeft<=0)
            {
                VD[i].defend.NowHealth -= VD[i].damage;
                VD[i].parent.GetComponent<TestT>().SpawnDamage(VD[i].damage,Color.red);
                if(VD[i].defend.NowHealth<=0)
                    {
                        Endbattle();
                        return;
                    }

                    VD[i].defend.getHpBar();
                    VD[i].defend.getTextHp();
                    
                    VD.RemoveAt(i);
                    max--;
                    break;
            }
            count++;
        }
            
        
    }
}
