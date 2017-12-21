using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class physic_moving_plane : MonoBehaviour {

	// Use this for initialization

	private Vector2 relativeForce;
	private Vector2 originalPosition;
	private bool flipflop;

	[Range(0,1000)]
	public float Range;
	public bool x = true;
	public bool y = false;

	void Start () {

		originalPosition = transform.position;

		if (!x && !y) GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
		if (!x &&  y) GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezePositionX;
		if (x  && !y) GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezePositionY;
		if (x  &&  y) GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
		
	}
	
	// Update is called once per frame
	void Update () {

		if (flipflop) {

			if(x)
				relativeForce = Vector2.left * Time.deltaTime * 10;
			if(y)
				relativeForce = Vector2.up * Time.deltaTime * 10;

		} else {
			if(x)
				relativeForce = Vector2.right * Time.deltaTime * 10;
			if(y)
				relativeForce = Vector2.down * Time.deltaTime * 10;

		}



		GetComponent<Rigidbody2D> ().AddRelativeForce (relativeForce);
	}

	void OnCollisionStay2D(Collision2D coll) {
		coll.transform.parent.GetComponent<Rigidbody2D>().AddRelativeForce(relativeForce);
	}
}
