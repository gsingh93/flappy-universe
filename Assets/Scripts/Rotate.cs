using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
	public float speed;

	void Start() {
		speed = 0.2 + Random.value;
	}

	void Update() {
		transform.localEulerAngles += speed * Vector3.forward;
	}
}
