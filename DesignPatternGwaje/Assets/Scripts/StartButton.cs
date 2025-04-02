using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("InGame");
    }
}
