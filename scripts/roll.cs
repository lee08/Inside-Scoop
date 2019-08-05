using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roll : abilities {
	public float boost = 1.0f;
	/*
	public float startdashtime;
	public float dashtime = 2.0f;*/
	//public float gravityafterdash = 5.0f;
	//public player1controllerwithjump p;

	/*public bool abled = true;
	private bool checkd = false;*/
	// Use this for initialization
	public Rigidbody2D rb;
	public crouch c;
	public Animator anim;
	public player1controllerwithjump p;
	private float gravnum;
	void OnDisable(){
		if (cooldown <= 0f) {
			cooldown = cooleddown;
			checkd = true;
		}
		starttime = 0f;
		playshort ();
	}

	void OnEnable(){
		//pppp = GameObject.FindGameObjectWithTag ("Player");
		if (GameMaster.pppppp == null) {
			p = GameObject.FindGameObjectWithTag ("Player").GetComponent<player1controllerwithjump> ();
			rb = GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody2D> ();
			c = GameObject.FindGameObjectWithTag ("Player").GetComponent<crouch> ();
			anim = GameObject.FindGameObjectWithTag ("Player").GetComponent<Animator> ();
		} else {
			p = GameMaster.pppppp.GetComponent<player1controllerwithjump> ();
			rb = GameMaster.pppppp.GetComponent<Rigidbody2D> ();
			c = GameMaster.pppppp.GetComponent<crouch> ();
			anim = GameMaster.pppppp.GetComponent<Animator> ();
		}
		gravnum = rb.gravityScale;
	}
	void Start () {
		//p = GetComponent<player1controllerwithjump> ();
	}

	// Update is called once per frame
	void Update () {

		//if (!stop) {
			aaa = true;
			if (Input.GetButton ("Fire1") && abled && c.iscrouch && starttime <= 0f) {

				starttime = duration;
				abled = false;
				anim.Play ("roll");
			} 
			if (cooldown > 0f) {
				cooldown -= Time.deltaTime;
				if (cooldown <= 0f) {
					abled = true;
				}
			}
			if (starttime > 0f) {
				checkd = false;
				rb.gravityScale = 100f;
				if (p.facingRight) {
				this.rb.velocity = new Vector2 (boost, 0);
					//this.rb.AddForce(new Vector2 (boost, 0));
					p.enabled = false;
					//this.rb.gravityScale = 0;
				} else {
				this.rb.velocity = new Vector2 (-boost, 0);	
				//this.rb.AddForce(new Vector2 (-boost, 0));
					p.enabled = false;
					//this.rb.gravityScale = 0;
				}
				starttime -= Time.deltaTime;
			} 
			if (starttime < 0f && !checkd) {
			rb.gravityScale = gravnum;
			anim.Play ("crouch");
			/*if (Input.GetButton("Down")) {
				Debug.Log ("yey");
				anim.Play ("crouch");
			} else {
				anim.Play ("crouch");
			}*/
				if (cooldown <= 0f) {
					cooldown = cooleddown;
					checkd = true;
				}
				p.enabled = true;
				//this.rb.gravityScale = gravityafterdash;


			}

		/*} else {
			if (cooldown <= 0f) {
				cooldown = cooleddown;
				checkd = true;
			}
			starttime = 0f;
			playshort ();

			//p.enabled = true;
			//this.rb.gravityScale = gravityafterdash;
		}*/
	}
	void playshort(){
		if (aaa) {
			//anim.Play ("idle");
		}
		aaa = false;
	}
}
