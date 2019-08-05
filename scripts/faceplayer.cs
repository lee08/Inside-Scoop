using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faceplayer : MonoBehaviour {
	public Transform target;
	float whex;
	public bool justsprites = false;
	public bool justcollider = false;
	// Use this for initialization
	void Start () {
		whex = this.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (!justcollider) {
			if (!justsprites) {
				if (target.transform.position.x - whex < 0) {
					Vector3 theScale = transform.localScale;
					theScale.x = -1;
					transform.localScale = theScale;
				} else {
					Vector3 theScale = transform.localScale;
					theScale.x = 1;
					transform.localScale = theScale;
				}
				/*if (target.transform.position.x - whex < 0) {
				this.GetComponentInParent<SpriteRenderer> ().flipX = true;
			} else {
				this.GetComponentInParent<SpriteRenderer> ().flipX = false;
			}*/

			} else {
				if (target.transform.position.x - whex < 0) {
					this.GetComponentInParent<SpriteRenderer> ().flipX = true;
				} else {
					this.GetComponentInParent<SpriteRenderer> ().flipX = false;
				}
			}
		} 
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag ("Player")) {
			if (!justsprites) {
				if (target.transform.position.x - whex < 0) {
					Vector3 theScale = transform.localScale;
					theScale.x = -1;
					transform.localScale = theScale;
				} else {
					Vector3 theScale = transform.localScale;
					theScale.x = 1;
					transform.localScale = theScale;
				}
				/*if (target.transform.position.x - whex < 0) {
				this.GetComponentInParent<SpriteRenderer> ().flipX = true;
			} else {
				this.GetComponentInParent<SpriteRenderer> ().flipX = false;
			}*/

			} else {
				if (target.transform.position.x - whex < 0) {
					this.GetComponentInParent<SpriteRenderer> ().flipX = true;
				} else {
					this.GetComponentInParent<SpriteRenderer> ().flipX = false;
				}
			}
		}
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.CompareTag ("Player")) {
			if (!justsprites) {
				if (target.transform.position.x - whex < 0) {
					Vector3 theScale = transform.localScale;
					theScale.x = -1;
					transform.localScale = theScale;
				} else {
					Vector3 theScale = transform.localScale;
					theScale.x = 1;
					transform.localScale = theScale;
				}
				/*if (target.transform.position.x - whex < 0) {
				this.GetComponentInParent<SpriteRenderer> ().flipX = true;
			} else {
				this.GetComponentInParent<SpriteRenderer> ().flipX = false;
			}*/

			} else {
				if (target.transform.position.x - whex < 0) {
					this.GetComponentInParent<SpriteRenderer> ().flipX = true;
				} else {
					this.GetComponentInParent<SpriteRenderer> ().flipX = false;
				}
			}
		}
	}
}
