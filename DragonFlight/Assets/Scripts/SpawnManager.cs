using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<Enemy> enemy;
    public int enemyNumber = 0;
    void Awake()
    {
        InvokeRepeating("SpawnEnemy", 3f, 0.5f);
    }

    void SpawnEnemy()
    {
        float randomX = Random.Range(-2f, 2f);

        Instantiate(enemy[Mathf.Min(enemyNumber,2)], new Vector3(randomX, transform.position.y, 0), Quaternion.identity);
    }
    
}
