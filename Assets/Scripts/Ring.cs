using UnityEngine;
using System.Collections;

public class Ring : MonoBehaviour {
	public Planet planet;

	private void OnMouseDown() {
		if (Camera.main.transform.position.z < -9) { // Hack
			Debug.Log(planet.getName());
			planet.OnMouseDown();
		}
	}
}
