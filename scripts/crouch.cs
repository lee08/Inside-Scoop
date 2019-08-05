using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crouch : MonoBehaviour {
	
	public float crouching = 3f;
	public bool iscrouch = false;
	public player1controllerwithjump p;
	// Use this for initialization
	void Start () {
		p = GetComponent<player1controllerwithjump> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Down") && p.grounded) {
			
			p.topSpeed = crouching;
			p.canJump = false;
			iscrouch = true;
		} else if  (iscrouch && p.grounded && !p.ceiling){
			p.topSpeed = crouching;
			p.canJump = false;
			iscrouch = true;
		}
		else if (p.ceiling){
			p.canJump = true;
			iscrouch = false;
		}
	}
}
