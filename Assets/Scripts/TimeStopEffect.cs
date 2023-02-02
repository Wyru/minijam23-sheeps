using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Bullet))]
public class TimeStopEffect : MonoBehaviour
{
    public GameObject timer;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Bullet>().OnBulletCollide += TimeStop;
    }

    void TimeStop(GameObject o){
        FreezesInTime fz = o.GetComponent<FreezesInTime>();
        if(fz!=null){
            fz.TimeStop();
            TimeStopTimer t = Instantiate(timer, o.transform).GetComponentInParent<TimeStopTimer>();
            t.StartTimer(fz);
        } 
    }
}
