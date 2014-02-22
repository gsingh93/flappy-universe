using UnityEngine;
using System.Collections;

public class Planet : SelectableObject {
	public string planetName;
	public bool buttonClicked = false;

	public float speed;
	public float radius;
	
	public const float maxSpeed = 0.5f;
	public const float minSpeed = 1f;

	public Texture[] textures;

	public Vector2 origin;

	private void Start() {
		base.Start ();
		renderer.material.mainTexture = textures[Random.Range(0, textures.Length)];
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
