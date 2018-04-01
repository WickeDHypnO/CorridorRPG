using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

	public float speed;
	void FixedUpdate () {
		transform.Rotate(Vector3.forward * speed);
	}
}
