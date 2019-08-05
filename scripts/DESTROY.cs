using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DESTROY : MonoBehaviour {

	// Use this for initialization
	[SerializeField]
	GameObject[] objectsToDestroy;

	public void DestroyGameObject(){
		foreach (GameObject objectToDestroy in objectsToDestroy) {
			Destroy (objectToDestroy);
		}
	}
}
