using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hasbeendone : MonoBehaviour {
	public bool notself = true;
	public int id;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (notself) {
			Destroy(transform.parent);

		} else {
			
	}
	}
}
