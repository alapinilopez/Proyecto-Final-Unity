using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatfrom : MonoBehaviour
{
    public float fallDelay;

    void OnCollisionEnter(Collision collidedWithThis)
    {
        if (collidedWithThis.gameObject.tag == "Player")
            {
                StartCoroutine(FallAfterDelay());
            }
        }

        IEnumerator FallAfterDelay()
        {
            yield return new WaitForSeconds(fallDelay);
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }