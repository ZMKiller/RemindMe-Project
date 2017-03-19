using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class CreateDialog : MonoBehaviour {

    // Use this for initialization
    public GameObject PlayerDialogStartPos;
    float height = 70;
    Dictionary<string, List<Dialog>> AllDialogs = new Dictionary<string, List<Dialog>>();
    List<Dialog> Ldialog = new List<Dialog>();
    public string nameDialog;
    public GameObject vibor;
    public GameObject dialog;
    float time = 5;
    bool start = false;
    float texttime = 0;
    float Bykvatime = 0.02f;
    string text = "asssssssssssssssssssssssssssssssssa";
    int index = 0;
    int id = -1;
    GameObject gm;
    List<GameObject> otv = new List<GameObject>();
    Text gmtext;
    bool dialogLog = false;

    public GameObject cr;
	void Start () {
        LoadTextMemory();
        // LoadText();
        Debug.Log(Camera.main.WorldToScreenPoint(cr.transform.position));
        Debug.Log("Scrin Height " + Screen.height);
        Debug.Log("Scrin Width  " + Screen.width);
        
    }
	
	// Update is called once per frame
	void Update () {
		if(start)
        {
            time -= Time.deltaTime;
            texttime += Time.deltaTime;
            if(texttime>= Bykvatime && index<text.Length)
            {
                texttime -= Bykvatime;
                gmtext.text += text[index];
                index++;
                if(index== text.Length-1 && dialogLog)
                {
                    createOtvets();
                }
            }
            if (time<=0 && !dialogLog)
            {
                start = false;
                Destroy(gm);
            }
        }
	}
    public void LoadText()
    {
        Debug.Log("Shop manager starting...");


        TextAsset bindata = Resources.Load("Dialogs/Dialogs") as TextAsset;
        
        //string serializedXML = bindata.text;
        //String value = "This is a short string.";
        XmlSerializer serializer = new XmlSerializer(typeof(Dictionary<string, List<Dialog>>));
        StringReader reader = new StringReader(bindata.text);
        AllDialogs = (Dictionary<string, List<Dialog>>)serializer.Deserialize(reader);
    }

    public void LoadTextMemory()
    {
        //TextAsset bindata2 = Resources.Load("Dialogs/T") as TextAsset;
        //Debug.Log("bin 2 + " + bindata2.text);
        try
        {
            TextAsset textAsset = (TextAsset)Resources.Load("Dialogs/Dialogs");
            byte[] bytes = textAsset.bytes;
            TextAsset ta = Resources.Load("Dialogs/Dialogs") as TextAsset;
            Stream s = new MemoryStream(ta.bytes);
            BinaryFormatter formatter = new BinaryFormatter();
            AllDialogs = (Dictionary<string, List<Dialog>>)formatter.Deserialize(s);
            
           // AllDialogs = (Dictionary<string, List<Dialog>>)bf.Deserialize(bindata.bytes);
            s.Close();
        }
        catch (System.Exception)
        {

            Debug.Log("ERROR");
        }

    }
    public void SetName(string name)
    {
        nameDialog = name;
        GetDialogs();
    }
    public void GetDialogs()
    {
        if(AllDialogs.ContainsKey(nameDialog))
        Ldialog = AllDialogs[nameDialog];
    }
    public int FindDialog()
    {
        for (int i = 0; i < Ldialog.Count; i++)
        {
          if(  Ldialog[i].startdialog)
            {
                return i;
            }
        }
        return -1;
    }
    public void create()
    {
        id = FindDialog();
        if(id >= 0)
        {
           text = Ldialog[id].textOtvet;
            if(Ldialog[id].OtvetId.Count>0)
            {
                dialogLog = true;
            }
        }
        else
        {
            dialogLog = false;
            text = "Я занят";
        }
        destroyDialog();
        gm =  Instantiate(dialog);
        gm.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
        gm.transform.localPosition = GetComponent<ClickedItems>().getPlayerDialogStartPos();
        gmtext = gm.GetComponentInChildren<Text>();
        gm.transform.localScale = new Vector3(1, 1, 1);
        gmtext.text = "";
        
        start = true;
        index = 0;
        // Bykvatime = (time - 2) / text.Length;
        time = 2 + Bykvatime * text.Length;
    }
    public void CreateNext()
    {
        text = Ldialog[id].textOtvet;
        if (Ldialog[id].OtvetId.Count > 0)
        {
            dialogLog = true;
        }
        else
        {
            dialogLog = false;
        }
        destroyDialog();
        gm = Instantiate(dialog);
        gm.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
        gm.transform.localPosition = GetComponent<ClickedItems>().getPlayerDialogStartPos();
        gm.transform.localScale = new Vector3(1,1,1);
        gmtext = gm.GetComponentInChildren<Text>();
        gmtext.text = "";

        start = true;
        index = 0;
        // Bykvatime = (time - 2) / text.Length;
        time = 2 + Bykvatime * text.Length;
        Global.OpenUI = false;
    }
    public void createOtvets()
    {
            DestroyOtvets();                
            for (int i = 0; i < Ldialog[id].OtvetId.Count; i++)
            {
                createOtvet(Ldialog[id].OtvetId[i]);
            }
        
    }
    public void DestroyOtvets()
    {
        if (otv.Count != 0)
        {
            for (int i = 0; i < otv.Count; i++)
            {
                Destroy(otv[i]);
            }
            otv.Clear();
        }
    }
    void createOtvet(int i)
    {
        otv.Add(Instantiate(vibor));
        otv[otv.Count - 1].GetComponent<ViborDialog>().text = Ldialog[i].textDialog;
        otv[otv.Count - 1].GetComponent<ViborDialog>().id = i;
        otv[otv.Count - 1].transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
        Vector3 vec = getPos();
        otv[otv.Count - 1].transform.localPosition = new Vector3(vec.x,vec.y-height* otv.Count-1);
        otv[otv.Count - 1].transform.localScale = new Vector3(1, 1, 1);
        Debug.Log("Count "+ otv.Count);
    }
    public void SelectOtvet(int idDialog)
    {
        try
        {
            destroyDialog();
            DestroyOtvets();
            id = idDialog;
            CreateNext();
        }
        catch (System.Exception)
        {

            
        }
    }
    public void IfDialogLenght()
    {
        if(dialogLog)
        {

        }
    }
    public Vector3 getPos()
    {
        RectTransform objectRectTransform = GameObject.Find("Canvas").GetComponent<RectTransform>();

        float mod = objectRectTransform.rect.height / (float)Screen.height;
        Vector3 v = Camera.main.WorldToScreenPoint(PlayerDialogStartPos.transform.position);
        Debug.Log("V " + v);
        Vector3 pos = new Vector3((v.x - Screen.width / 2) * mod, (v.y - Screen.height / 2) * mod);
        return pos;
    }
    public void destroyDialog()
    {
 try
        {
            start = false;
            Destroy(gm);
        }
        catch (System.Exception)
        {

            
        }
    }
}
