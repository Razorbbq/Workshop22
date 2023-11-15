using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float enemySpawnTime;
    [SerializeField] float spawnDecrease;
    [SerializeField] float spawnFloor;
    float timer;
    [SerializeField] GameObject enemy;

    [SerializeField] Vector2 upperRight;
    [SerializeField] Vector2 lowerLeft;
    [SerializeField] float bufferZone;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            timer = enemySpawnTime;
            enemySpawnTime -= spawnDecrease;
            if(enemySpawnTime < spawnFloor)
            {
                enemySpawnTime = spawnFloor;
            }
            Vector2 pos = new Vector2(RandomPos(upperRight.x, lowerLeft.x), RandomPos(upperRight.y, lowerLeft.y));


            Instantiate(enemy, pos, Quaternion.identity);

        }
    }

    private float RandomPos(float up, float down)
    {
        if(Random.Range(0,2) > 0)
        {
            if (up < 0) bufferZone *= -1;
            return Random.Range(up, up + bufferZone);
        }
        else
        {
            if (down < 0) bufferZone *= -1;
            return Random.Range(down, down + bufferZone);
        }
    }
}
