using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSpawn : MonoBehaviour
{

    public Transform[] points;

    public float timeBtwSpawns;

    float cTime;

    public GameObject food;

    // Update is called once per frame
    void Update()
    {
        if(cTime > timeBtwSpawns){
            int i = Random.Range(0, points.Length);
            Instantiate(food, points[i].position, Quaternion.identity);
            cTime = 0;
        }
        cTime += Time.deltaTime;
    }
}
