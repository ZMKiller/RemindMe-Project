using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewDamage  {

   public float TimeLeft;
    public GameObject parent;
    public int damage;
    public Person defend;
    
    public ViewDamage(float timeleft, GameObject _parent, int _damage, Person _defend)
    {
        TimeLeft = timeleft;
        parent = _parent;
        damage = _damage;
        defend = _defend;

    }
    
}
