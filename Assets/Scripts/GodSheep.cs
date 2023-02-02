using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GodSheep : MonoBehaviour
{

    public int life;

    public float cooldown;

    public bool idle;
    public bool jumping;
    public bool goHigh;

    private Animator ani;

    public float speed;

    float ctime;

    Vector2 playerPos;

    public Transform anchorBody, anchorHand;

    public static GodSheep Instance;

    public bool readyToFight;
    public bool lutando;

    public AudioClip introAudioClip;
    public AudioClip beeeeClip;
    public AudioClip dieeClip;
    public AudioSource audioSource;

    bool onDead;

    public GameObject bulletSheep;

    public static event Action OnBossDie;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ani = GetComponent<Animator>();
        ctime = 0;
        Instance = this;
        readyToFight = false;
    }

    // Update is called once per frame
    void Update()
    {

        if(life < 0){
            if(!onDead){
                if(OnBossDie != null){
                    OnBossDie.Invoke();
                }
                SceneManager.LoadScene("End");
                onDead = true;
            }
        }

        if (lutando == false)
        {
            if (readyToFight)
            {
                if (Vector2.Distance(transform.position, playerPos) > .5f)
                {
                    transform.position = Vector2.MoveTowards(transform.position, playerPos, 3*speed * Time.deltaTime);
                }
                else
                {
                    audioSource.PlayOneShot(introAudioClip);
                    lutando = true;
                }
            }
            return;

        }



        while (ctime > cooldown)
        {
            if (idle)
            {
                // int i = 2;
                int i = UnityEngine.Random.Range(0, 4);

                switch (i)
                {
                    case 0:
                        ctime = 0;
                        audioSource.PlayOneShot(beeeeClip);
                        break;

                    case 1:
                        ani.SetTrigger("Attack");
                        idle = false;
                        playerPos = Player.Instance.transform.position;
                        audioSource.PlayOneShot(dieeClip);
                        SheepBullet b = Instantiate(bulletSheep, anchorHand.position, Quaternion.identity).GetComponent<SheepBullet>();
                        b.Shoot(playerPos);
                        break;

                    case 2:
                        ani.SetTrigger("Jump");
                        idle = false;
                        jumping = true;
                        goHigh = true;
                        playerPos = Player.Instance.transform.position;
                        audioSource.PlayOneShot(beeeeClip);
                        break;

                    case 3:
                        ani.SetTrigger("Attack");
                        idle = false;
                        playerPos = Player.Instance.transform.position;
                        audioSource.PlayOneShot(dieeClip);
                        b = Instantiate(bulletSheep, anchorHand.position, Quaternion.identity).GetComponent<SheepBullet>();
                        b.Shoot(playerPos);
                        break;
                }
                ctime = 0;
            }
        }

        if (jumping)
        {
            if (goHigh)
            {
                transform.position += transform.up * speed * Time.deltaTime;
            }
            else
            if (Vector2.Distance(transform.position, playerPos) > .5f)
            {
                transform.position = Vector2.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);
            }
        }
        ctime += Time.deltaTime;
    }

    public void SetIdle()
    {
        idle = true;
        jumping = false;
    }

    public void Fall()
    {
        goHigh = false;
    }


    public void takeDamage()
    {
        life -= 5;
    }



}
