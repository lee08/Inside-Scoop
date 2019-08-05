using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Interact : MonoBehaviour {
	private GameMaster gm;
	//public Text Textt;
//	public string talk;
	public Dialog[] dial;
	public int index;
	public bool talkable = true;
	float whex;
	public LineRenderer indicate;
	public Camera came;
	public basiccamfollow camefol;
	public float speed = 0.5f;
	public float thicc;
	//public float csize = 10.0f;
	//public float csizen;
	//public float num;
	//public Vector3 nums;
	//private bool ye = false;
	//private Interact aaa;
	//public Vector3 offsets;
	//public Vector3 offsetsed;


	// Use this for initialization
	void Start () {
		gm = GameObject.FindGameObjectWithTag ("GameMaster").GetComponent<GameMaster>();
		came = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera>();
		camefol = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<basiccamfollow>();
		whex = this.transform.position.x;
		indicate = this.GetComponent<LineRenderer> ();
		thicc = this.GetComponent<SpriteRenderer> ().bounds.extents.x;
		//aaa = transform.parent.GetComponent<Interact>();
		//csize = this.GetComponent<CameraSize> ();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		/*if (aaa != null) {
			csizen = aaa.csizen;
			offsetsed = aaa.offsetsed;
		} else {
			if (csizen < 1.0f) {
				csizen = came.orthographicSize;
			}
			//offsetsed = camefol.offset;
		}*/
		//num = csizen;
		//nums = offsetsed;
		if (col.CompareTag ("Player")) 
		{
			if ((col.transform.position.x - whex < 1.0f &&col.GetComponent<player1controllerwithjump>().facingRight)||(col.transform.position.x - whex > -1.0f&&!col.GetComponent<player1controllerwithjump>().facingRight)) {
				//Textt.text = talk;
				if (talkable && indicate != null) {
					indicate.enabled = true;
				}

				if (Input.GetButtonDown ("Interact")) 
				{
					//Textt.text = talk;
					/*if (csize > 1.0f){
						num = csize;
						nums = offsets;
						//ye = true;
					}*/
					if (talkable && !GameMaster.istalking) {
						dial [index].enabled = true;
						index += 1;
						if (index >= dial.Length) {
							index = 0;
						}
					}
				}
				/*if (dial [index].enabled == false) {
					num = csizen;
					nums = offsetsed;
				}*/
			}
			else {
				if (indicate != null) {
					indicate.enabled = false;
				}
			}

		}
	}

	void OnTriggerStay2D(Collider2D col)
	{
		/*if (aaa != null) {
			csizen = aaa.csizen;
			offsetsed = aaa.offsetsed;
		} else {
			if (csizen < 1.0f) {
				csizen = came.orthographicSize;
			}
			//offsetsed = camefol.offset;
		}*/
		//num = csizen;
		//nums = offsetsed;
		if (col.CompareTag ("Player")) 
		{
			if ((col.transform.position.x - whex < 1.0f &&col.GetComponent<player1controllerwithjump>().facingRight)||(col.transform.position.x - whex > -1.0f&&!col.GetComponent<player1controllerwithjump>().facingRight)) {
				//Textt.text = talk;
				if (talkable && indicate != null) {
					indicate.enabled = true;
				}

				if (Input.GetButtonDown ("Interact")) 
				{
					//Textt.text = talk;
					/*if (csize > 1.0f){
						num = csize;
						nums = offsets;
						//ye = true;
					}*/
					if (talkable && !GameMaster.istalking) {
						dial [index].enabled = true;
						index += 1;
						if (index >= dial.Length) {
							index = 0;
						}
					}
				}
				/*if (dial [index].enabled == false) {
					num = csizen;
					nums = offsetsed;
				}*/
			}
			else {
				if (indicate != null) {
					indicate.enabled = false;
				}
			}

		}
	}

	void OnTriggerExit2D(Collider2D col){
		if (col.CompareTag ("Player")) 
		{
			//num = csizen;
			//nums = offsetsed;

			//Textt.text = ("");
			if (indicate != null) {
				indicate.enabled = false;
			}
		}
	}

	void Update(){
		/*if (ye) {
			change (num, nums);
		}
		if (came.orthographicSize != null) {
			if (came.orthographicSize == csizen) {
				ye = false;
			}
		}*/
	}
	/*void change(float size, Vector3 place) {
		if (csize >= 1.0f) {
			came.orthographicSize = Mathf.Lerp (came.orthographicSize, size, speed);
			camefol.offset.x = Mathf.Lerp (camefol.offset.x, place.x, speed);
			camefol.offset.y = Mathf.Lerp (camefol.offset.y, place.y, speed);
			camefol.offset.z = Mathf.Lerp (camefol.offset.z, place.z, speed);
		}
	}*/
}
