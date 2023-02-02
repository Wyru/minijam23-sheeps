using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FreezesInTime : MonoBehaviour
{
    public bool freezed;
    public GameObject normalBody;
    public GameObject freezedBody;

    public static event Action<FreezesInTime> OnTimeStoped;

    public static event Action<FreezesInTime> OnTimeUnstoped;

    public virtual void TimeStop(){
        if(freezed)
            return;
        freezed = true;
        normalBody.SetActive(false);
        freezedBody.SetActive(true);
        if(OnTimeStoped != null){
            OnTimeStoped.Invoke(this);
        }
    }

    public virtual void UnstopTime(){
        StopAllCoroutines();
        freezed = false;
        normalBody.SetActive(true);
        freezedBody.SetActive(false);
        if(OnTimeUnstoped != null){
            OnTimeUnstoped.Invoke(this);
        }
    }

    public void TimeIsTicking(){
        StartCoroutine(Blink());
    }

    IEnumerator Blink(){
        bool white = false;
        while(freezed){
            normalBody.SetActive(white);
            freezedBody.SetActive(!white);
            white = !white;
            yield return new WaitForSeconds(.1f);
        }
    }


}
