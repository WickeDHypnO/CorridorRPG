using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToCamera : MonoBehaviour {

    Transform target;
    
    void Start()
    {
        target = Camera.main.transform;
    }

	void Update () {
        Vector3 look = new Vector3(target.position.x, transform.position.y, target.position.z);
        transform.LookAt(-look);
	}
}
