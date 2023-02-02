using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TrickleSheep : MonoBehaviour
{
    public Vector2 destiny;
    public float speed;

    public bool go;

    public GameObject sheep;

    public static event Action OnLand;


    private void Start() {
    }
    

    void Update()
    {
        if(!go)
            return;
        
        if(Vector2.Distance(transform.position, destiny) < 2f){
            Land();
        }
        else{
            transform.position = Vector2.MoveTowards(transform.position, destiny, speed * Time.deltaTime);
        }
    }

    void Land(){
        Instantiate(sheep, transform.position, Quaternion.identity);
        if(OnLand != null){
            OnLand.Invoke();
        }
        Destroy(gameObject);
    }

    public void Go(Vector2 d){
        destiny = d;
        go = true;
    }






}
