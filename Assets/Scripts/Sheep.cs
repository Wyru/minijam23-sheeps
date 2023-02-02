using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : FreezesInTime
{
    public float speed;
    public float minDistance;

    private float distanceToPlayer;

    private Vector2 destiny;

    public bool beingCarried;

    private Animator ani;

    public int score;

    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(beingCarried){
            GetComponent<BoxCollider2D>().enabled = false;
            transform.localPosition = Vector2.zero;
            transform.localEulerAngles = Vector2.zero;

            ani.SetBool("Carry",true);
            return;
        }
        else{
            ani.SetBool("Carry",false);
        }

        if(freezed){
            return;
        }

        GetComponent<BoxCollider2D>().enabled = true;
        
        
        distanceToPlayer = Vector2.Distance(transform.position,Player.Instance.transform.position) ;

        if(distanceToPlayer < minDistance ){
            ChooseDestiny();
            transform.position = Vector2.MoveTowards(transform.position, Player.Instance.transform.position, -speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, destiny, speed * Time.deltaTime);
            if(Vector2.Distance(transform.position, destiny) < 2f){
                ChooseDestiny();
            }
        }
    }

    void ChooseDestiny(){
        destiny = new Vector2(
            Random.Range(-20, 20),
            Random.Range(-20, 20)
        );
    }
}
