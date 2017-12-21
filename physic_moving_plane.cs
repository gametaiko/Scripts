using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class physic_moving_plane : MonoBehaviour {

	// Use this for initialization
	private Vector2 relativeForce;
	private Vector2 originalPosition;
	private bool flipflop;
	private Transform target;
	[Range(0,100)]
	public float Range;

	[Range(0,100)]
	public float Speed;

	public bool x = true;
	public bool y = false;

	void Start () {
		originalPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		if (flipflop) {
			if(x)
				relativeForce = Vector2.left * Time.deltaTime * Speed;
			if(y)
				relativeForce = Vector2.up * Time.deltaTime * Speed;
		} else {
			if(x)
				relativeForce = Vector2.right * Time.deltaTime * Speed;
			if(y)
				relativeForce = Vector2.down * Time.deltaTime * Speed;
		}
			
		transform.Translate (relativeForce);

		if(target != null)
		target.Translate (relativeForce);

		if (transform.position.x > originalPosition.x + Range) {
			flipflop = true;
		}
		if (transform.position.x < originalPosition.x - Range) {
			flipflop = false;
		}
		if (transform.position.y > originalPosition.y + Range) {
			flipflop = false;
		}
		if (transform.position.y < originalPosition.y - Range) {
			flipflop = true;
		}
	}

	void OnCollisionStay2D(Collision2D coll) {
		
		if (coll.gameObject.tag == "Tyre")
			target = coll.transform.root;
	}
}
