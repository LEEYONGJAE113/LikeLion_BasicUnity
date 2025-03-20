using Unity.Cinemachine;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance;
    //Impulse Source 컴포넌트 참조
    private CinemachineImpulseSource impulseSource;

    void Start()
    {
        Instance = this;
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    // 카메라 쉐이크
    public void CameraShakeShow()
    {
        if(impulseSource != null)
        {
            //기본 설정으로 임펄스 생성
            impulseSource.GenerateImpulse();
        }
    }

    void Update()
    {
        
    }
}
