using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProperties : MonoBehaviour {
    public Transform finalPos;
    Vector3 Target;
    public int speed = 1000;

	void Start () {
        Target = finalPos.position;
	}
	
	void Update () {
        float step = Time.deltaTime * speed;
        transform.position = Vector3.MoveTowards(transform.position, Target, Time.deltaTime * step);
        float distance = Vector3.Distance(transform.position, Target);
        if (distance < 0.1f) 
        {
            if(Target == finalPos.position)
            {
                Destroy(gameObject);
            }
        }
    }
}

