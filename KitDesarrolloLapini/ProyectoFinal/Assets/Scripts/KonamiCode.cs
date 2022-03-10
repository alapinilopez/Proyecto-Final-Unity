using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KonamiCode : MonoBehaviour
{
    private const float waitTime = 0.5f;

    private KeyCode[] keys = new KeyCode[]
    {
        KeyCode.UpArrow,
        KeyCode.UpArrow,
        KeyCode.DownArrow,
        KeyCode.DownArrow,
        KeyCode.LeftArrow,
        KeyCode.RightArrow,
        KeyCode.LeftArrow,
        KeyCode.RightArrow,
        KeyCode.B,
        KeyCode.A,
    };

    public bool success;

    IEnumerator Start()
    {
        float timer = 0f;
        int index = 0;
        while(true)
        {
            if (Input.GetKeyDown(keys[index]))
            {
                index++;

                if(index == keys.Length)
                {
                    success = true;
                    timer = 0f;
                }
                timer = waitTime;
            }

            timer -= Time.deltaTime;
            if (timer < 0)
            {
                timer = 0;
                index = 0;
            }
            yield return null;
        }
    }


}
