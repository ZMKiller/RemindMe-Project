using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonFight  {

    // Use this for initialization
    Animator animator;
    GameObject Person;
   public PersonFight(Animator _animator, GameObject _Person)
    {
        animator = _animator;
        Person = _Person;
        
    }

    public void StarAttack(string str)
    {
        animator.SetTrigger(str);
       
    }
    public string GetNowClipName()
    {
       // Debug.Log(animator.GetCurrentAnimatorClipInfo(0)[0].clip.name);
       return animator.GetCurrentAnimatorClipInfo(0)[0].clip.name;
    }
    public void startFight()
    {
        animator.SetBool("IsFight", true);
    }
    public void endFight()
    {
        animator.SetBool("IsFight", false);
    }
}
