using Unity.Mathematics;
using UnityEngine;

public class Slash : MonoBehaviour
{
    private GameObject p;
    Vector3 mousePos;
    Vector3 dir;

    float angle;
    Vector3 dirNo;

    public Vector3 direction = Vector3.right;
    void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player");

        Transform tr = p.GetComponent<Transform>();
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector3 pos = new Vector3(mousePos.x, mousePos.y, 0);
        dir = pos - tr.position;

        angle = Mathf.Atan2(dir.y, dir.x) *  Mathf.Rad2Deg;
    }


    void Update()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
        transform.position = p.transform.position;
    }

    public void Des()
    {
        Destroy(gameObject);
    }
}
