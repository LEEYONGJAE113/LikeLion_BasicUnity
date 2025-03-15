using Unity.Mathematics;
using UnityEngine;

public class BossHead : MonoBehaviour
{
    public GameObject bossBullet;
    
    public void RightDownLaunch()
    {
        GameObject bullet = Instantiate(bossBullet, transform.position, Quaternion.identity);

        bullet.GetComponent<BossBullet>().Move(new Vector2(1, -1));
    }

    public void LeftDownLaunch()
    {
        GameObject bullet = Instantiate(bossBullet, transform.position, Quaternion.identity);

        bullet.GetComponent<BossBullet>().Move(new Vector2(-1, -1));
    }
    public void DownLaunch()
    {
        GameObject bullet = Instantiate(bossBullet, transform.position, Quaternion.identity);

        bullet.GetComponent<BossBullet>().Move(new Vector2(0, -1));
    }
}
