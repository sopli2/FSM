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
    
    int length = 60;

    public bool activateLights;
    public GameObject[] lights;

    // Start is called before the first frame update
    void Start()
    {
        ppv = gameObject.GetComponent<Volume>();
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].SetActive(false); // shut them off
        }
        activateLights = false;
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
        if(sec <= (length / 2))
        {
            ppv.weight = (float)sec / (length/2); // day to night (0 to 1)
            // 1 - (float)sec / (length / 2);
            if (activateLights == false)
            {
                if(sec > (length / 6))
                {
                    for (int i = 0; i < lights.Length; i++)
                    {
                        lights[i].SetActive(true); // shut them off
                    }
                    activateLights = true;
                }
            }
        }
        else if(sec <= length)
        {
            ppv.weight = (float)(length - sec) / (length/2); // night to day (1 to 0)
            // (float)sec / (length / 2) - 1;
            if(activateLights == true)
            {
                if(sec > (length - length/6))
                {
                    for (int i = 0; i < lights.Length; i++)
                    {
                        lights[i].SetActive(false); 
                    }
                    activateLights = false;
                }
            }
        }
    }

}
