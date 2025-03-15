using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public PlayerBullet bullet;
    WaitForSeconds shootInterval;
    bool readyToShoot;
    void Start()
    {
        shootInterval = new WaitForSeconds(0.1f);
        // StartCoroutine(Shoot());
        readyToShoot = true;
    }

    void Update()
    {
        if ((Input.GetKey(KeyCode.Space) || Input.GetKeyDown(KeyCode.Space) ) && readyToShoot)
        {
        StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        readyToShoot = false;
        Instantiate(bullet, transform.position, Quaternion.identity);
        yield return shootInterval;
        readyToShoot = true;
    }

    // IEnumerator Shoot()
    // {
    //     while (gameObject.activeSelf)
    //     {
    //         yield return shootInterval;
    //         Instantiate(bullet, transform.position, Quaternion.identity);
    //     }
    // }
}
