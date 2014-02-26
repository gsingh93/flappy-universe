using UnityEngine;
using System.Collections;

public class Revolve : MonoBehaviour {
	public float speed = 1f;
	public float radius = 1f;

	private float angularVelocity;
	private GameObject parent;

	private float offset;

	private void Start() {
		parent = transform.parent.gameObject;
		angularVelocity = speed / radius;
		offset = Random.value * 6.8f;
	}

	private void Update() {
		float angle = offset + Time.time * angularVelocity;
		transform.position = parent.transform.position + radius * new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
	}
}
