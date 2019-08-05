using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class abilities : MonoBehaviour {
	public float cooldown;
	public float cooleddown = 2.0f;
	//public float boost = 1.0f;
	public float starttime;
	public float duration = 2.0f;
	//public float gravityafterdash = 5.0f;

	public bool ishappening = false;
	public bool abled = true;
	public bool checkd = false;
	//public bool stop = false;
	public bool aaa = true;
	//public GameObject pppp;
	// Use this for initialization
	/*Rigidbody2D rb;
	private crouch c;
	public Animator anim;
	void Awake(){
		rb = GetComponent<Rigidbody2D> ();
		c = GetComponent<crouch> ();
		anim = GetComponent<Animator> ();
	}*/
	void OnEnable () {
		
	}

	// Update is called once per frame
	void Update () {
		/*if (Input.GetButton ("Move1") && Input.GetButtonDown ("Fire1") && abled && !c.iscrouch) {
			anim.Play ("dash");
			startdashtime = dashtime;
			abled = false;
		}*/ 
		if (cooldown > 0f) {
			cooldown -= Time.deltaTime;
			if (cooldown <= 0f) {
				abled = true;
			}
		}/*
		if (startdashtime > 0f) {
			checkd = false;
			if (p.facingRight) {
				this.rb.velocity = new Vector2 (boost, 0);
				p.enabled = false;
				this.rb.gravityScale = 0;
			} else {
				this.rb.velocity = new Vector2 (-boost, 0);
				p.enabled = false;
				this.rb.gravityScale = 0;
			}
			startdashtime -= Time.deltaTime;
		} 
		if(startdashtime < 0f && !checkd) {
			if (cooldown <= 0f) {
				cooldown = cooleddown;
				checkd = true;
			}
			p.enabled = true;
			anim.Play ("idle");
			this.rb.gravityScale = gravityafterdash;
		}
*/
	}
}
