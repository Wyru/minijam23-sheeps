using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip storeSheep;
    public AudioClip sheepLand;
    public AudioClip hitSheep;
    public AudioClip playerHeal;
    public AudioClip playerDamage, bulletExplode;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Barn.OnStoreSheep += StoreSheep;

        Player.OnTakeDamage += PlayerDamage;
        Player.OnHeal += PlayerHeal;

        TrickleSheep.OnLand += OnLand;

        FreezesInTime.OnTimeStoped += OnHitSheep;

        Bullet.OnBulletExplode += BulletExplode;

    }

    void StoreSheep(Sheep sheep)
    {
        if (audioSource != null)
            audioSource.PlayOneShot(storeSheep);
    }

    void PlayerHeal()
    {
        if (audioSource != null)
            audioSource.PlayOneShot(playerHeal);
    }

    void PlayerDamage()
    {
        if (audioSource != null)
            audioSource.PlayOneShot(playerDamage);
    }

    void OnLand()
    {
        if (audioSource != null)
            audioSource.PlayOneShot(sheepLand);
    }

    void OnHitSheep(FreezesInTime f)
    {
        if (audioSource != null)
            audioSource.PlayOneShot(hitSheep);
    }

    void BulletExplode()
    {
        if (audioSource != null)
            audioSource.PlayOneShot(bulletExplode);
    }
}
