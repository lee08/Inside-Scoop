using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallbound : MonoBehaviour {
	
	//[SerializeField] private Transform player;
	[SerializeField] public Transform respawnpoint;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag ("Player")) {
			col.transform.position = respawnpoint.transform.position;
		}

	}

}
