using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(KonamiCode))]
public class CheatMode : MonoBehaviour
{
    private KonamiCode code;
    private void Awake()
    {
        code = GetComponent<KonamiCode>();
    }

    void Update()
    {
        if(code.success)
        {
            SceneManager.LoadScene(31);
        }
    }
}
