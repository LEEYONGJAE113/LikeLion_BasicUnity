
using UnityEngine;

public class ConditionExample : MonoBehaviour
{
    public int Health = 100;
    void Update()
    {
        Health -= 1;
        Debug.Log($"Health : {Health}"); // option + Esc

        if (Health <= 0)
        {
            Debug.Log("Game Over!");
            return;
        }
    }

}
