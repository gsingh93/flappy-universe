using UnityEngine;
using System.Collections;

public class Planet : SelectableObject {
	public string planetName;
	public bool buttonClicked = false;

	public float speed;
	public float radius;
	
	public const float maxSpeed = 0.01f;
	public const float minSpeed = 0.2f;

	public Texture[] textures;

	public Vector2 origin;

	private GameObject parent;

	new private void Start() {
		base.Start ();
		parent = transform.parent.gameObject;
		renderer.material.mainTexture = textures[Random.Range(0, textures.Length)];
	}

	private void Update() {
		float angle = Time.time * speed;
		transform.position = parent.transform.position + radius * new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
	}

	#region implemented abstract members of SelectableObject
	public override string getName ()
	{
		return planetName;
	}

	public override string[] getOptions ()
	{
		return new string[] {"Build Mine"};
	}

	public override void OnOptionSelected (string option)
	{
		Debug.Log ("Planet " + planetName + " selected option " + option);
	}
	#endregion
}
