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
    public GameObject Boss;

    [SerializeField]
    GameObject textBossWarning;

    void Awake()
    {
        textBossWarning.SetActive(false);

        foreach (var monster in monsters)
        {
            PoolManager.Instance.CreatePool(monster, 10);
        }
    }

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

            // Instantiate(monsters[0], randVec, Quaternion.identity);
            GameObject monster = PoolManager.Instance.Get(monsters[0]);
            monster.transform.position = randVec;
        }
    }
    void Stop()
    {
        swi[0] = false;
        StopCoroutine("RandomSpawn1");
        swi[1] = true;
        StartCoroutine("RandomSpawn2");
        Invoke("Stop2", SpawnStopTime);
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

    void Stop2()
    {
        swi[1] = false;
        StopCoroutine("RandomSpawn2");
        textBossWarning.SetActive(true);
        CameraShake.Instance.CameraShakeShow();
        StartCoroutine("Shake");

        Vector3 pos = new Vector3(0, transform.position.y - 1.6f, 0);
        Instantiate(Boss, pos, Quaternion.identity);
    }



    IEnumerator Shake()
    {
        yield return new WaitForSeconds(0.2f);
        CameraShake.Instance.CameraShakeShow();
        yield return new WaitForSeconds(0.2f);
        CameraShake.Instance.CameraShakeShow();
        yield return new WaitForSeconds(0.2f);
        CameraShake.Instance.CameraShakeShow();

    }
}
