using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runoffscreen : MonoBehaviour {
	public int number;
	public float cooldown;
	Rigidbody2D rb;
	public SpriteRenderer rr;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rr = GetComponent<SpriteRenderer> ();
		if (rb == null) {
			rb = GetComponentInParent<Rigidbody2D> ();
		}
		if (rr == null) {
			rr = GetComponentInParent<SpriteRenderer> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		rr.flipX = false;
		rb.velocity = new Vector2(number, rb.velocity.y);

		if (cooldown > 0f) {
			cooldown -= Time.deltaTime;
		} else {
			Destroy (transform.parent.gameObject);
		}
	}

	void OnBecameInvisible(){
		rr.enabled = false;

	}
}
