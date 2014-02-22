using UnityEngine;
using System.Collections;

public class Revolve : MonoBehaviour {
	public float speed = 1f;
	public float radius = 1f;

	private float angularVelocity;
	private GameObject parent;

	private void Start() {
		parent = transform.parent.gameObject;
		angularVelocity = speed / radius;
	}

	private void Update() {
		float angle = Time.time * angularVelocity;
		transform.position = parent.transform.position + radius * new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
	}
}
