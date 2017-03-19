using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonSkill  {

    public string SkillName;
    public int energyCost;
    public float Time;
    public float modifyDmg;
    public PersonSkill(string name , int cost, float time, float _modifyDmg)
    {
        SkillName = name;
        energyCost = cost;
        Time = time;
        modifyDmg = _modifyDmg;
    }
}
