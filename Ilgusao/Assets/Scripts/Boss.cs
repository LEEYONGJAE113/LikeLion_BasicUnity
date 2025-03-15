using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour
{
    int flag = 1;
    int speed = 2;

    public GameObject mb;
    public GameObject mb2;
    public Transform pos1;
    public Transform pos2;
    void Start()
    {
        StartCoroutine(BossMissile());
        StartCoroutine(CircleFire());
    }

    IEnumerator BossMissile()
    {
        while (true)
        {
            Instantiate(mb, pos1.position, Quaternion.identity);
            Instantiate(mb, pos2.position, Quaternion.identity);

            yield return new WaitForSeconds(0.5f);
        }
    }

    // 원으로 미사일 발사
    IEnumerator CircleFire()
    {
        // 공격주기
        float attackRate = 3;
        // 발사체 생성개수
        int count = 30;
        // 발사체 사이의 각도
        float intervalAngle = 360 / count;
        // 가중되는 각도 (항상 같은 위치로 발사 안되도록)
        float weightAngle = 0f;

        // 원 형태로 방사하는 발사체 생성 (count 만큼)
        while (true)
        {
            for (int i = 0; i < count; ++i)
            {
                // 발사체 생성
                GameObject clone = Instantiate(mb2, transform.position, Quaternion.identity);
                // 발사체 이동 방향(각도)
                float angle = weightAngle + (intervalAngle * i);
                //발사체 이동 방향(벡터)
                //Cos(각도)라디안 단위의 각도 표현을 위해 pi/180을 곱함
                float x = Mathf.Cos(angle * Mathf.Deg2Rad);
                //sin(각도)라디안 단위의 각도 표현을 위해 pi/180을 곱함
                float y = Mathf.Sin(angle * Mathf.Deg2Rad);

                //발사체 이동 방향 설정
                clone.GetComponent<BossBullet>().Move(new Vector2(x, y));
            }

            // 발사체 생성 각도 이동
            ++weightAngle;

            yield return new WaitForSeconds(attackRate);
        }
    }

    void Update()
    {
        if(transform.position.x >= 1 || transform.position.x <= -1)
        {
            flag *= -1;
        }

        transform.Translate(flag * speed * Time.deltaTime, 0, 0);
    }

}
