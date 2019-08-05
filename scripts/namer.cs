using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class namer : MonoBehaviour {
	private GameMaster gm;
	public string chek;
	public string delet;
	//public bool needtointeract = false;
	public bool awaken = false;

	private bool here = false;
	void Start(){
		gm = GameObject.FindGameObjectWithTag ("GameMaster").GetComponent<GameMaster>();

	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag ("Player")) 
		{
			//if (!needtointeract) {
				if (!gm.did.Contains (chek)) {
					gm.did.Add (chek);
				}
				if (delet != null) {
					if (gm.did.Contains (delet)) {
						gm.did.Remove (delet);
					}
				}
			/*} else {
				if (Input.GetButtonDown("Interact")) {
					gm.did.Add (chek);
					if (delet != null) {
						gm.did.Remove (delet);
					}
				}
			}*/
		}

	}
	void OnTriggerStay2D(Collider2D col)
	{
		if (col.CompareTag ("Player")) 
		{
			if (!gm.did.Contains (chek)) {
				gm.did.Add (chek);
			}
			if (delet != null) {
				if (gm.did.Contains (delet)) {
					gm.did.Remove (delet);
				}
			}
		}

	}

	void OnEnable(){
		if (awaken){
			if (!gm.did.Contains (chek)) {
				gm.did.Add (chek);
			}
			if (delet != null) {
				if (gm.did.Contains (delet)) {
					gm.did.Remove (delet);
				}
			}
		}

	}

}
