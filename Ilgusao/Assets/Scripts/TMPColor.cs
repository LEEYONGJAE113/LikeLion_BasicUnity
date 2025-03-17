using System.Collections;
using TMPro;
using UnityEngine;

public class TMPColor : MonoBehaviour
{
    [SerializeField]
    float lerpTime = 0.1f;

    TextMeshProUGUI textBossWarning;

    void Awake()
    {
        textBossWarning = GetComponent<TextMeshProUGUI>();
    }

    void OnEnable()
    {
        StartCoroutine(ColorLerpLoop());
    }
    
    //색상 전환 루프 코루틴
    IEnumerator ColorLerpLoop()
    {
        while (true)
        {
            yield return StartCoroutine(ColorLerp(Color.white, Color.red));
            yield return StartCoroutine(ColorLerp(Color.red, Color.white));
        }
    }
    
    //색상 전환 코루틴
    IEnumerator ColorLerp(Color startColor, Color endColor)
    {
        float currentTime = 0f;
        float percent = 0f;

        while (percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / lerpTime;
            textBossWarning.color = Color.Lerp(startColor, endColor, percent);
            yield return null;
        }
    }
}
