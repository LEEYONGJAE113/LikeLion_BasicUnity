using UnityEngine;

public class Player
{
    public string Name;
    public int Score;

    public Player(string name, int score)
    {
        Name = name;
        Score = score;
    }

    public void ShowInfo()
    {
        Debug.Log($"Player : {Name}, Score : {Score}");
    }
}
public class ClassExample : MonoBehaviour
{

    void Start()
    {
        Player player = new Player("Hero", 10);
        player.ShowInfo();
    }


    void Update()
    {
        
    }
}
