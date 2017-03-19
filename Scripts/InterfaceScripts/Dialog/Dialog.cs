using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Dialog  {
   public string PersonId;
   public int DialogId;
   public bool startdialog;
    public bool children;
    public int NeedReputation;
   public string textDialog;
   public string textOtvet;
   public List<int> OtvetId = new List<int>();
   public int ChangeReputation;
   public Dialog(string _PresonId,int _DialogId)
    {
        PersonId = _PresonId;
        DialogId = _DialogId;
        NeedReputation = 0;
        textDialog = "";
        textOtvet = "";
        OtvetId = new List<int>();
        ChangeReputation = 0;
        children = false;
        startdialog = false;
    }
}
