using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DayNightCycle : MonoBehaviour
{
    public Volume ppv;

    public float tic;
    public float sec;
    public int min;
    public int day;

    public bool activateLights;
    public GameObject[] lights;

    // Start is called before the first frame update
    void Start()
    {
        ppv = gameObject.GetComponent<Volume>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CalcTime();
    }

    public void CalcTime()
    {
        sec += Time.fixedDeltaTime * tic;

        if(sec >= 60)
        {
            sec = 0;
            min += 1;
        }
        if(min >= 30)
        {
            min = 0;
            day += 1;
        }

        ControlPPV();
    }

    public void ControlPPV()
    {
        if(sec <= 30)
        {
            ppv.weight = 1 - (float)sec / 30;
            if (activateLights == true)
            {
                if(sec > 20)
                {
                    for (int i = 0; i < lights.Length; i++)
                    {
                        lights[i].SetActive(false); // shut them off
                    }
                    activateLights = false;
                }
            }
        }
        else if(sec <= 60)
        {
            ppv.weight = (float)sec / 30 - 1;

            if(activateLights == false)
            {
                if(sec > 50)
                {
                    for (int i = 0; i < lights.Length; i++)
                    {
                        lights[i].SetActive(true); 
                    }
                    activateLights = true;
                }
            }
        }
    }

}
