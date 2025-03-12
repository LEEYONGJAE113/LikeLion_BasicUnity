using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Launcher launcher;
    public SpawnManager spawner;
    public Text ScoreText;
    public Text StartText;
    public Text UpgradeText;
    public Text NewEnemyText;
    public Text GameOverText;

    int score = 0;

    public float spawnInterval = 0f;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        int i = 3;

        while (i > 0)
        {
            StartText.text = i.ToString();

            yield return new WaitForSeconds(1);
            --i;

            if (i == 0)
            {
                StartText.gameObject.SetActive(false);
            }
        }

    }

    public void AddScore(int num)
    {
        score += num;
        ScoreText.text = $"Score : {score}";
        if (score % 300 == 0)
        {
            launcher.bulletCount = Mathf.Min(++launcher.bulletCount, 3);
            if (score > 600) { return; }
            StartCoroutine(TextCoroutine(UpgradeText));
        }
    }

    IEnumerator TextCoroutine(Text text)
    {
        text.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        text.gameObject.SetActive(false);
        StopCoroutine(TextCoroutine(text));
    }

    void FixedUpdate()
    {
        if (spawner.enemyNumber >= 2) { return; }
        spawnInterval += Time.fixedDeltaTime;
        if(spawnInterval > 20)
        {
            spawner.enemyNumber = ++spawner.enemyNumber;
            spawnInterval = 0f;
            StartCoroutine(TextCoroutine(NewEnemyText));
        }
    } 
}
