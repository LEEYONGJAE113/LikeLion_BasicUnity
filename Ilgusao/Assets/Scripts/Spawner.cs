using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float SpawnPointLeft = -2f;
    public float SpawnPointRight = 2f;
    public float SpawnStartTime = 1f;
    public float SpawnStopTime = 10f;
    bool[] swi = new bool[2];

    public List<GameObject> monsters;


    void Start()
    {
        swi[0] = true;
        StartCoroutine("RandomSpawn1", 0);
        Invoke("Stop", SpawnStopTime);
    }

    IEnumerator RandomSpawn1()
    {
        while (swi[0])
        {
            yield return new WaitForSeconds(SpawnStartTime);
            float x = Random.Range(SpawnPointLeft, SpawnPointRight);
            Vector2 randVec = new Vector2(x, transform.position.y);

            Instantiate(monsters[0], randVec, Quaternion.identity);
        }
    }
    void Stop()
    {
        swi[0] = false;
        StopCoroutine("RandomSpawn1");
        swi[1] = true;
        StartCoroutine("RandomSpawn2");
    }

    IEnumerator RandomSpawn2()
    {
        while (swi[1])
        {
            yield return new WaitForSeconds(SpawnStartTime);
            float x = Random.Range(SpawnPointLeft, SpawnPointRight);
            Vector2 randVec = new Vector2(x, transform.position.y);

            Instantiate(monsters[1], randVec, Quaternion.identity);
        }
    }
}
