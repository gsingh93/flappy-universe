using UnityEngine;
using System.Collections;

public class Star : Celestial {
	private GameObject redgiant;
	private float finalScale;

	private void Start () {
		base.Start ();

		stateType = "Yellow Star";
		nextStarState = "Red Giant";
		nextStarState.Trim ();
		starLabelOffset = 27f;
	}
	
	override public void nextState () {

		rigidbody.isKinematic = true;
		collider.isTrigger = true;
		renderer.enabled = false;
		(gameObject.GetComponent ("Halo") as Behaviour).enabled = false;
		lblShowing = false;

		redgiant = (GameObject)Instantiate(Resources.Load("RedGiant"), transform.position, transform.rotation);
		finalScale = redgiant.transform.localScale.x;
		redgiant.transform.localScale = transform.localScale;
		redgiant.transform.parent = transform.parent;
		redgiant.GetComponent<Celestial> ().lblShowing = false;


		StartCoroutine ("growStar");
	}

	private IEnumerator growStar () {
		float growTimer = 0f;

		Vector3 changeVect = new Vector3 ();
		float changeVel = (finalScale - transform.localScale.x) / transitionTime;

		while (growTimer < transitionTime) {
			growTimer += Time.deltaTime;

			changeVect.x = changeVect.y = changeVect.z = Mathf.Clamp01(changeVel*growTimer)*(finalScale - transform.localScale.x)+transform.localScale.x;
			redgiant.transform.localScale = changeVect;

			yield return null;
		}
		
		redgiant.GetComponent<Celestial> ().lblShowing = true;
		Destroy (gameObject);  
	}

}