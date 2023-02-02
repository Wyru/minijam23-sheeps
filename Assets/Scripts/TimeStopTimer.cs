using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStopTimer : MonoBehaviour
{
    public float maxTime;

    private float currentTime = 0;
    private FreezesInTime f;
    private bool start;
    private bool timeWasTick = false;

    // Update is called once per frame
    void Update()
    {
        if(!start) return;

        if((currentTime/maxTime) > .6 && !timeWasTick){
            timeWasTick= true;
            f.TimeIsTicking();
        }

        if(currentTime > maxTime){
            f.UnstopTime();
            Destroy(gameObject);
        }
        else{
            currentTime += Time.deltaTime;
        }
    }

    public void StartTimer(FreezesInTime f){
        this.f = f;
        start = true;
    }
}
