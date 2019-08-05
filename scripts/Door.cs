using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Door : Interact {
	public string LevelToLoad;
	private GameMaster gm;
	//public Text Textt;
	public bool autonextscene = false;
	public Transform tr;
	//public GameObject main;

	// Use this for initialization

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag ("Player")) 
		{
			//Debug.Log ("a");
			//Textt.text = ("Exit");
			if (indicate != null) {
				indicate.enabled = true;
			}
			if (Input.GetButtonDown("Interact")) 
			{
				if (tr == null) {
					SceneManager.LoadScene (LevelToLoad);
				} else {
					col.transform.position = tr.position;
					//main.transform.position = tr.position;
				}
			}
		}
		if (autonextscene) {
			if (tr == null /*|| main == null*/) {
				SceneManager.LoadScene (LevelToLoad);
			} else {
				col.transform.position = tr.position;
				//main.transform.position = tr.position;
			}
		}
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.CompareTag ("Player")) 
		{
			if (indicate != null) {
				indicate.enabled = true;
			}
			if (Input.GetButtonDown ("Interact")) 
			{
				if (tr == null) {
					SceneManager.LoadScene (LevelToLoad);
				} else {
					col.transform.position = tr.position;
					//main.transform.position = tr.position;
				}
			}
		}
		if (autonextscene) {
			if (tr == null /*|| main == null*/) {
				SceneManager.LoadScene (LevelToLoad);
			} else {
				col.transform.position = tr.position;
				//main.transform.position = tr.position;
			}
		}
	}

	void OnTriggerExit2D(Collider2D col){
		//Textt.text = ("");
		if (indicate != null) {
			indicate.enabled = false;
		}
	}


}
