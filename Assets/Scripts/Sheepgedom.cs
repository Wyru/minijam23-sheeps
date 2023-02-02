using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheepgedom : MonoBehaviour
{

    public Animator sheepgeddonAnimator;

    public int maxSheeps;
    public int cSheeps = 0;


    public AudioClip music;

    public AudioSource audioSource;

    public GodSheep god;

    public bool worldEnded;

    public Animator bossHealth;

    void Start()
    {
        TrickleSheep.OnLand += Increase;
        Barn.OnStoreSheep += Decrease;
    }

    void Update()
    {
        if (cSheeps >= maxSheeps)
        {
            EndOfTheWorld();
        }
    }

    private void Increase()
    {
        cSheeps++;
    }

    private void Decrease(Sheep sheep)
    {
        cSheeps--;
    }

    public void EndOfTheWorld()
    {
        if (!worldEnded)
        {
            sheepgeddonAnimator.SetTrigger("end");
            audioSource.Stop();
            audioSource.clip = music;
            audioSource.Play();
            god.readyToFight = true;
            bossHealth.SetTrigger("In");
        }

        worldEnded = true;
    }
}
