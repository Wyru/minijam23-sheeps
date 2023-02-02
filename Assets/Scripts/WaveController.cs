using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{

    public BoxCollider2D land;
    public BoxCollider2D cloud;

    public float timeBtwSpawn;
    private float currentTime;

    public GameObject[] sheeps;


    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime > timeBtwSpawn)
        {
            SpawnSheep();
            currentTime = 0;
        }
        else{
            currentTime += Time.deltaTime;
        }
    }

    public void SpawnSheep()
    {
        int index = Random.Range(0, sheeps.Length);
        TrickleSheep ts = Instantiate(sheeps[index], ChooseSpawnPoin(),Quaternion.identity).GetComponent<TrickleSheep>();
        ts.Go(ChooseLandingPoint());
    }


    public Vector2 ChooseLandingPoint()
    {
        Bounds bounds = land.bounds;
        return new Vector2(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y)
        );
    }

    public Vector2 ChooseSpawnPoin()
    {
        Bounds bounds = cloud.bounds;
        return new Vector2(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y)
        );
    }
}
