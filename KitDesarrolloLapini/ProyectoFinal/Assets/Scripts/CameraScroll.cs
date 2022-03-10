using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour
{
    public float scrollSpeed;
    public Transform endGame;

    void Update(){

        Vector3 target = endGame.position - endGame.forward + Vector3.up * 1.2f;
        float delta = Time.deltaTime * scrollSpeed;
        transform.position = Vector3.MoveTowards(transform.position, target, delta);
    }
}
