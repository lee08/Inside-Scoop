using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ingamecutscene : MonoBehaviour {
	private GameMaster gm;
	//public Text Textt;
	public bool autonextscene = false;
	public Dialog di;
	// Use this for initialization
	void Start () {
		gm = GameObject.FindGameObjectWithTag ("GameMaster").GetComponent<GameMaster>();
		//Physics2D.IgnoreLayerCollision(0, 2, true);
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag ("Player")) {
			//Debug.Log ("a");
			//Textt.text = ("Exit");
			if (Input.GetButtonDown ("Interact") || autonextscene) {
				di.enabled = true;
				di.NextSentence ();
			}

			Destroy (this);
		} else {
			Physics2D.IgnoreCollision (col, GetComponent<Collider2D> ());
		}


	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.CompareTag ("Player")) 
		{
			if (Input.GetButtonDown ("Interact")) 
			{
				di.enabled = true;
				di.NextSentence ();
			}
			if (autonextscene) {
				di.enabled = true;
				di.NextSentence ();
			}
		}

		Destroy(this);
	}

	void OnTriggerExit2D(Collider2D col){
		//Textt.text = ("");
	}
}
