using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameMaster : MonoBehaviour {
	public static bool istalking =  false;
	public static GameMaster Instance;
	public static GameObject pppppp;
	[SerializeField]
	public bool keep;
	public static List<int> cando = new List<int>();
	public List<string> did = new List<string>();

	//public Vector2 lastcheckpointpos;
	// Use this for initialization
	void Awake()  {
		if(Instance == null){
			DontDestroyOnLoad(gameObject);
			Instance = this;
		}
		else if (Instance != this){
			//Destroy (gameObject);
			if (!keep) {
				Destroy (gameObject);
			}
		}
	}

	void Start(){
		pppppp = GameObject.FindGameObjectWithTag ("Player");
		enableabilities ();
	}

	// Update is called once per frame
	void Update () {
		if (pppppp == null) {
			pppppp = GameObject.FindGameObjectWithTag ("Player");
		}
	}

	public void enableabilities(){
		//pppppp = GameObject.FindGameObjectWithTag ("Player");
		foreach (int a in cando) {
			if (a == 0) {
				this.GetComponent<dash> ().enabled = false;
				Debug.Log ("asfsg");
				this.GetComponent<dash> ().aaa = true;
				this.GetComponent<dash> ().enabled = true;
			}
			else if (a == 1) {
				this.GetComponent<roll> ().enabled = false;
				Debug.Log ("sasfsg");
				this.GetComponent<roll> ().aaa = true;
				this.GetComponent<roll> ().enabled = true;
			}
			else if (a == 2) {
				this.GetComponent<dashup> ().enabled = false;

				this.GetComponent<dashup> ().aaa = true;
				this.GetComponent<dashup> ().enabled = true;
			}
			//(this.GetComponent (a) as abilities).enabled = false;
			//a.enabled = false;

			//a.enabled = true;
			//(this.GetComponent (a) as abilities).enabled = true;
		}
	}
	public void disableabilities(){
		foreach (int a in cando) {
			if (a == 0) {
				//this.GetComponent<dash> ().stop = true;
				this.GetComponent<dash> ().enabled = false;
			}
			else if (a == 1) {
				//this.GetComponent<roll> ().stop = true;
				this.GetComponent<roll> ().enabled = false;
			}
			else if (a == 2) {
				//this.GetComponent<roll> ().stop = true;
				this.GetComponent<dashup> ().enabled = false;
			}
		}
	}

}
/*public static class GlobalVariables{
	 
}*/