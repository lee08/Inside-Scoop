using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basiccamfollow : MonoBehaviour {
	public Transform player;
	public Vector3 offset;
	public bool followy = true;
	public bool snapy = false;
	private float ypos;

	void Start(){
		//getplayery ();
		ypos = player.position.y;
	}

	void Update () 
	{
		if (followy) {
			getplayery ();
		} 
		transform.position = new Vector3 (player.position.x + offset.x, ypos + offset.y, player.position.z + offset.z); // Camera follows the player with specified offset position

		if (snapy) {
			transform.position = new Vector3 (player.position.x + offset.x, player.position.y + offset.y, player.position.z + offset.z); // Camera follows the player with specified offset position
		}
	}

	void getplayery(){
		ypos = Mathf.Lerp(ypos, player.position.y, 0.2f);
	}
}