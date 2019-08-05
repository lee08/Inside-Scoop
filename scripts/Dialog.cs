using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Dialog : MonoBehaviour {
	[System.Serializable]
	public class MyEventType : UnityEvent { }

	[System.Serializable]
	public class Sentence
	{
		public float typingSpeed = 0.02f;
		public string name;
		public Color namecolor;
		public string line;
		public Sprite portrait;
		public Animationname[] aabs;
		public MyEventType action;
		public bool goon = false;
		public bool destroy = false;
		public bool question = false;

		public Sentence(float typ, string nam, Color namcol, string lin, Sprite portrai, Animationname[] aaba, MyEventType actio, bool goo, bool destro, bool questio)
		{
			typingSpeed = typ;
			name = nam;
			namecolor = namcol;
			line = lin;

			portrait = portrai;
			aabs=aaba;
			action = actio;
			goon = goo;
			destroy = destro;
			question = questio;
		}
	}
	[System.Serializable]
	public class Animationname
	{
		public Animator animator;
		public string emote;
		public Animationname(Animator animato,string emot)
		{
			animator = animato;
			emote= emot;
		}
	}

	[System.Serializable]
	public class Questionne
	{
		public GameObject button;
		public string choice;
		public Questionne(GameObject butto,string choic)
		{
			button = butto;
			choice= choic;
		}
	}


	public Sentence[] sentences;
	public GameObject can;
	private int index;
	//public float[] typingSpeed;
	public bool done = true;
	private faceplayer facc;
	//public bool question;

	public TextMeshProUGUI textDisplay;
	public TextMeshProUGUI nameDisplay;
	public SpriteRenderer background;
	public SpriteRenderer nameground;
	public SpriteRenderer portraitground;
	public GameObject contin;
	public GameObject questionbox;


	private bool didntdothisbefore = true;
	private GameObject ppppp;
	private crouch c;
	private GameMaster gm;
	public bool playedemote;
	public bool grump = false;

	//[HideInInspector]
	public Questionne[] qlist;

	void Start(){
		//can = GameObject.FindGameObjectWithTag ("canvas");
		textDisplay = GameObject.FindGameObjectWithTag ("textmeshpro").GetComponent<TextMeshProUGUI>();
		nameDisplay = GameObject.FindGameObjectWithTag ("nametext").GetComponent<TextMeshProUGUI>();
		background = GameObject.FindGameObjectWithTag ("wordbackground").GetComponent<SpriteRenderer>();
		nameground = GameObject.FindGameObjectWithTag ("nametext").GetComponent<SpriteRenderer>();
		portraitground = GameObject.FindGameObjectWithTag ("portrait").GetComponent<SpriteRenderer>();
		contin = GameObject.FindGameObjectWithTag ("continue");
		questionbox = GameObject.FindGameObjectWithTag ("questions");
	}

	void OnEnable(){
		//StartCoroutine (Type ());
		//can = GameObject.FindGameObjectWithTag ("canvas");
		can.SetActive(true);
		textDisplay = GameObject.FindGameObjectWithTag ("textmeshpro").GetComponent<TextMeshProUGUI>();
		nameDisplay = GameObject.FindGameObjectWithTag ("nametext").GetComponent<TextMeshProUGUI>();
		background = GameObject.FindGameObjectWithTag ("wordbackground").GetComponent<SpriteRenderer>();
		nameground = GameObject.FindGameObjectWithTag ("nametext").GetComponent<SpriteRenderer>();
		portraitground = GameObject.FindGameObjectWithTag ("portrait").GetComponent<SpriteRenderer>();
		contin = GameObject.FindGameObjectWithTag ("continue");
		questionbox = GameObject.FindGameObjectWithTag ("questions");

		GameMaster.istalking = true;
		index = -1;
		didntdothisbefore = true;
		ppppp = GameObject.FindGameObjectWithTag ("Player");
		gm = GameObject.FindGameObjectWithTag ("GameMaster").GetComponent<GameMaster>();
		c = ppppp.GetComponent<crouch> ();
	}

	IEnumerator Type(){
		
		done = false;
		playedemote = false;
		nameDisplay.text = sentences [index].name;
		nameDisplay.color = sentences [index].namecolor;

		if (sentences [0].aabs.Length == 0) {
			Debug.Log ("nyup");
			ppppp.GetComponent<Animator> ().Play ("idle");
		}

		if (background != null) {	
			if (sentences [index].line != "") {
			background.enabled = true;
		} else {
			background.enabled = false;
			}
		}
		if (nameground != null) {	
			if (sentences [index].name != "") {
				nameground.enabled = true;
			} else {
				nameground.enabled = false;
			}
		}
		portraitground.sprite = sentences [index].portrait;
		if (sentences [index].action != null) {
			sentences [index].action.Invoke ();
		}

		if (sentences [index].aabs.Length != 0 && !playedemote) {
			//ppppp.GetComponent<PlayerAnim> ().enabled = false;
			foreach (Animationname aab in sentences [index].aabs) {
				aab.animator.Play (aab.emote);
			}
			playedemote = true;
		}
		/*else {
			ppppp.GetComponent<PlayerAnim> ().enabled = true;
		}*/

			foreach (char letter in sentences[index].line.ToCharArray()) {
			if (!done) {
				
				textDisplay.text += letter;
				yield return new WaitForSeconds (sentences[index].typingSpeed);
			}
			}



		/*if (sentences [index].action.Length != 0) {
			if (!(sentences [index].destroy)) {
				foreach (GameObject act in sentences [index].action) {
					act.SetActive (true);
				}
			} else {
				foreach (GameObject act in sentences [index].action) {
					act.SetActive (false);
				}
			}
		}*/
		if (!(sentences [index].question)) {
			can.transform.GetChild (5).gameObject.SetActive (false);
			can.transform.GetChild (1).gameObject.SetActive (true);

			grump = false;
		}
		else{
			can.transform.GetChild (5).gameObject.SetActive (true);
			can.transform.GetChild (1).gameObject.SetActive (false);
			//question button lock itself up and prevents further dialogue
			foreach(Questionne p in qlist){
				Debug.Log ("gyeah");
				p.button.SetActive (true);
				p.button.transform.SetParent(can.transform.GetChild (5).transform.GetChild (0).transform.GetChild (0).transform);

			}
			grump = true;
		}
		if (sentences [index].goon) {
			//Input.GetButtonDown ("Interact");
			NextSentence (true);
		} else {
			done = true;
		}
	}

	public void NextSentence(bool d = false){
		if (index < sentences.Length - 1 && done || index < sentences.Length - 1 && d) {
			index++;
			textDisplay.text = "";
			//Debug.Log ("shouldbecaing");
			StartCoroutine (Type ());

		} else if (!done&&!d) {
			done = true;
			//Debug.Log ("shouldbecaling");
			textDisplay.text = sentences[index].line;

		}
		else { //end of dialogue
			textDisplay.text = "";
			Debug.Log ("th");
			can.SetActive(false);
			GameMaster.istalking = false;
			//Debug.Log ("shouldbecalling");
			this.enabled = false;
		}
	}

	void OnClick(){
		OnEnable ();
		grump = false;
		NextSentence();
	}

	void Update(){
		if (Input.GetButtonDown ("Interact") && !grump)
		{
			NextSentence();
		}
		if (GameMaster.istalking && didntdothisbefore) {
			gm.disableabilities ();
			/*foreach (abilities a in GameMaster.cando) {
				if(!a.stop){
					a.stop = true;
				}*/
				//a.enabled = false;
			//}
			ppppp.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
			ppppp.GetComponent<player1controllerwithjump> ().move=0.0f;
			//ppppp.GetComponent<BoxCollider2D>().sharedMaterial.friction = 1f;
			ppppp.GetComponent<player1controllerwithjump> ().iswalking = false;
			//ppppp.GetComponent<player1controllerwithjump> ().running = false;
			ppppp.GetComponent<player1controllerwithjump> ().enabled = false;
			Animator anim = ppppp.GetComponent<Animator> ();
			anim.SetBool ("jump", false);
			anim.SetBool ("running", false);
			anim.SetBool ("crouchwalking", false);
			anim.SetBool ("walking", false);
			anim.SetBool ("crouching", false);
			

			ppppp.GetComponent<PlayerAnim> ().enabled = false;
			//ppppp.GetComponent<Animator> ().Play ("idle");
			c.iscrouch = false;
			ppppp.GetComponent<crouch> ().enabled = false;




			/*foreach (GameObject cann in sentences[index].line.ToCharArray()) {
				GameMaster.
			}*/
			didntdothisbefore = false;
		} else if (!GameMaster.istalking) {
			//ppppp.GetComponent<BoxCollider2D>().sharedMaterial.friction = 0f;
			ppppp.GetComponent<player1controllerwithjump> ().enabled = true;
			ppppp.GetComponent<PlayerAnim> ().enabled = true;
			ppppp.GetComponent<crouch> ().enabled = true;
			/*foreach (abilities a in GameMaster.cando) {
				a.stop = false;
				a.enabled = true;
			}*/

			gm.enableabilities ();
		}
	}
	//find a way to mult choice and close/open different dialogues
}
