using UnityEngine;
using System;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float timeToDestroy;

    public Vector2 dir;

    private bool shooted;

    public event Action<GameObject> OnBulletCollide;

    public GameObject timeStopEffect;

    public static event Action OnBulletExplode;
   

    private void Start() {
        Invoke("DestroyThis", timeToDestroy);
    }

    private void Update()
    {
        if(shooted){
            transform.Translate(dir * speed * Time.deltaTime);
        }
    }

    public void Shoot(Vector3 pos)
    {
        dir =  pos - transform.position;
        dir.Normalize();
        shooted = true;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(OnBulletCollide != null){
            if(other.gameObject.CompareTag("Boss")){
                other.GetComponent<GodSheep>().takeDamage();
            }
            OnBulletCollide.Invoke(other.gameObject);

        }
        DestroyThis();
    }

    private void DestroyThis()
    {
        GameObject go = Instantiate(timeStopEffect, transform.position, Quaternion.identity);
        if(OnBulletExplode!=null){
            OnBulletExplode.Invoke();
        }
        Destroy(go, 2f);
        Destroy(gameObject);
    }
}