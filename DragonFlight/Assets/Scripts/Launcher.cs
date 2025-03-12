using System.Collections;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public int bulletCount = 1;
    public GameObject bullet; // 미사일 프리팹
    void Awake()
    {
        // InvokeRepeating(함수 이름, 초기 지연시간, 지연할 시간)
        InvokeRepeating("Shoot", 3f, 0.5f);
    }

    void Shoot()
    {
        SoundManager.Instance.PlayBulletSound();
        switch (bulletCount)
        {
            case 1:
                Instantiate(bullet, transform.position, Quaternion.identity);

                break;
            case 2:
                Instantiate(bullet, new Vector3(transform.position.x - 0.2f, transform.position.y, 0), Quaternion.identity);
                Instantiate(bullet, new Vector3(transform.position.x + 0.2f, transform.position.y, 0), Quaternion.identity);

                break;
            case 3:
                Instantiate(bullet, transform.position, Quaternion.identity);
                Instantiate(bullet, new Vector3(transform.position.x - 0.3f, transform.position.y, 0), Quaternion.identity);
                Instantiate(bullet, new Vector3(transform.position.x + 0.3f, transform.position.y, 0), Quaternion.identity);

                break;
        }

    }

    

}
