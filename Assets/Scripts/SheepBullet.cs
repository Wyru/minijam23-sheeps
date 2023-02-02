using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepBullet : MonoBehaviour
{
    public float speed;
    public float timeToDestroy;
    public Vector2 dir;
    private bool shooted;
    
    private void Start()
    {
        Invoke("DestroyThis", timeToDestroy);
    }

    private void Update()
    {
        if (shooted)
        {
            transform.Translate(dir * speed * Time.deltaTime);
        }
    }

    public void Shoot(Vector3 pos)
    {
        dir = pos - transform.position;
        dir.Normalize();
        shooted = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Player>().takeDamage();
            DestroyThis();

        }

    }

    private void DestroyThis()
    {
        Destroy(gameObject);
    }

}
