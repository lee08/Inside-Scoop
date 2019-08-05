using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour {
	private fallbound gm;

	void Start(){
		gm = GameObject.FindGameObjectWithTag ("oof").GetComponent<fallbound>();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag ("Player")) {
			gm.respawnpoint = this.transform;
		}

	}
}
