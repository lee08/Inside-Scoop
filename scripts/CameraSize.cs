using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CameraSize : MonoBehaviour {
	
	public Camera cam;
	public basiccamfollow camfol;
	public float speed = 0.5f;
	public float size;
	public bool transition = false;
	public bool movey = false;
	public bool snappy = false;
	public bool turny = true;
	public GameObject posity;
	public GameObject ppp;
	public Vector3 oofset;

	// Use this for initialization
	void Start () {
		cam = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera>();
		camfol = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<basiccamfollow>();
		ppp = GameObject.FindGameObjectWithTag ("Player");
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag ("Player")) 
		{
			camfol.followy = movey;
			camfol.snapy = snappy;
			transition = true;
			camfol.enabled = turny;
			if (posity != null) {
				ppp.GetComponent<player1controllerwithjump> ().enabled = false;
				GameObject.FindGameObjectWithTag ("MainCamera").transform.position = posity.transform.position;
				ppp.GetComponent<player1controllerwithjump> ().enabled = true;
			}
		}
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.CompareTag ("Player")) 
		{
			if (oofset != null) {
				camfol.offset = oofset;
			}
			camfol.followy = movey;
			camfol.snapy = snappy;
			transition = true;
			camfol.enabled = turny;
			if (posity != null) {
				ppp.GetComponent<player1controllerwithjump> ().enabled = false;
				GameObject.FindGameObjectWithTag ("MainCamera").transform.position = posity.transform.position;
				ppp.GetComponent<player1controllerwithjump> ().enabled = true;
			}
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if (col.CompareTag ("Player")) 
		{
			transition = false;
		}
	}


	void Update(){
		if (transition) {
			cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, size, speed);
		}
	}


}
