using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class placer : MonoBehaviour {
	[System.Serializable]
	public class MyEventType : UnityEvent { }

	private GameMaster gm;
	public string chek;
	public Transform pt;
	public Transform player;
	public bool depend = false;
	public bool sensitive = false;
	public MyEventType action;

	void Start(){
		gm = GameObject.FindGameObjectWithTag ("GameMaster").GetComponent<GameMaster>();
		foreach (string strin in gm.did) {
			if (strin == chek) {
				if (sensitive) {
					action.Invoke ();
				}
				if (!depend) {
					player.position = pt.position;
				}
				depend = false;

			}
		}
		if (depend) {
			Destroy (gameObject);
		}
	}

}
