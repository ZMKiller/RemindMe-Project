using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTime : MonoBehaviour {

    public GameObject data;
    public GameObject time;
    public NeedsBar needsbar;
    Text dataText;
    Text timeText;
    int days;
    int weaks;
    int moons;
    int years;
    string Sdays;
    string Sweaks;
    string Smoons;
    string Syears;

    int Hours;
    int Minutes;
    int Tminut;
    string Shours;
    string Sminutes;

    bool TimeStart;
    int TimeSpeed;

    float seconds = 0;
	void Start () {
        dataText = data.GetComponent<Text>();
        timeText = time.GetComponent<Text>();

        TimeStart = false;
        TimeSpeed = 240;
        days = 1;
        weaks = 0;
        moons = 0;
        years = 0;

        Hours = 12;
        Minutes = 30;
        needsbar = GetComponent<NeedsBar>();
    }
	
	// Update is called once per frame
	void Update () {

        timeUpdate();




    }
    void timeUpdate()
    {
        seconds += Time.deltaTime;
        if(seconds>=1)
        {
            seconds -= 1;
            ColculateTime();
        }
    }
    void ColculateData()
    {
        days += 1;
        
        if (days >= 7)
        {
            days -= 7;
            weaks += 1;
            if (weaks >= 4)
            {
                weaks -= 4;
                moons += 1;
                if (moons >= 12)
                {
                    moons -= 12;
                    years += 1;
                }
            }
        }
        Sdays = "0" + days;
        Sweaks = "0" + weaks;
        if(moons<10)
        {
            Smoons = "0" + moons;
        }
        else
        {
            Smoons = moons.ToString();    
        }
        if (years < 10)
        {
            Syears = "0" + years;
        }
        else
        {
            Syears = years.ToString();
        }
        dataText.text = Syears + ":" + Smoons + ":" + Sweaks + ":" + Sdays;
    }
    void ColculateTime()
    {
        Tminut = Minutes;
        Minutes += TimeSpeed;
        Tminut = Minutes - Tminut;
        while (Minutes >= 60)
        {
            if (Minutes >= 60)
            {
                Minutes -= 60;
                Hours += 1;
                if (Hours >= 24)
                {
                    Hours -= 24;
                    ColculateData();
                }
            }

        }
        if (Minutes < 10)
        {
            Sminutes = "0" + Minutes;
        }
        else
        {
            Sminutes = Minutes.ToString();
        }
        if (Hours < 10)
        {
            Shours = "0" + Hours;
        }
        else
        {
            Shours = Hours.ToString();
        }
        timeText.text = Shours + ":" + Sminutes;
        TimeBarChange();
    }
    public void TimeBarChange()
    {

        needsbar.ChangeHealth(needsbar.speedDropHealth* Tminut);
        needsbar.ChangeFood(needsbar.speedDropFood * Tminut);
        needsbar.ChangeEnergy(needsbar.speedDropEnergy * Tminut);
    }
}
