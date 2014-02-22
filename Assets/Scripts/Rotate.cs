using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
	public float speed = 0.5f;

	void Update() {
		transform.localEulerAngles += speed * Vector3.forward;
	}
}
