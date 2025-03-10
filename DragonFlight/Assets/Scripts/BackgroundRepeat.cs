using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeat : MonoBehaviour
{
    // 스크롤할 속도를 상수로 지정
    public const float SCROLL_SPEED = 0.3f;
    // 쿼드와 매테리얼 데이털르 받아올 객체 선언
    private Material _thisMaterial;

    void Start()
    {
        // 객체가 생성될 때 최초 1회 호출되는 함수
        // 현재 객체의 Component들을 참조해 Renderer라는 컴포넌트의 Material 정보를 가져옴
        _thisMaterial = GetComponent<Renderer>().material;
    }

    void Update()
    {
        // 새롭게 지정해줄 Offset 객체 선언
        Vector2 newOffset = _thisMaterial.mainTextureOffset;
        // y부분에 현재 y값의 속도에 프레임을 보정해 더해줌
        newOffset.Set(0, newOffset.y + (SCROLL_SPEED * Time.deltaTime));
        //최종적으로 offset값 지정
        _thisMaterial.mainTextureOffset = newOffset;
    }
}
