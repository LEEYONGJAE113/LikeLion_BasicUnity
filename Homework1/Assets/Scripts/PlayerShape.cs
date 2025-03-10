using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShape : MonoBehaviour
{
    

    System.Random random;
    
    void Start()
    {
        random = new System.Random();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            int shape = random.Next(0,4);
            for (int i = 0; i < transform.childCount; ++i)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
            switch (shape)
            {
                case 0:
                    for (int i = 0; i < 3; ++i)
                    {
                        transform.GetChild(i).gameObject.SetActive(false);
                    }
                    break;
                case 1:
                    transform.GetChild(2).gameObject.SetActive(false);
                    transform.GetChild(3).gameObject.SetActive(false);
                    break;
                case 2:
                    transform.GetChild(0).gameObject.SetActive(false);
                    transform.GetChild(5).gameObject.SetActive(false);
                    break;
                case 3:
                    transform.GetChild(3).gameObject.SetActive(false);
                    transform.GetChild(5).gameObject.SetActive(false);
                    break;
            }
        }
    }
}
