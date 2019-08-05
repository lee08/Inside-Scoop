using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class candoability : MonoBehaviour {
	//[System.Serializable]
	public int[] script;
	private GameMaster gm;
	void Start(){
		gm = GameObject.FindGameObjectWithTag ("GameMaster").GetComponent<GameMaster>();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		
		if (col.CompareTag ("Player")) {
			foreach (int a in script) {
				GameMaster.cando.Add (a);
		}
			gm.enableabilities ();
		Destroy(gameObject);
		}
	}
}