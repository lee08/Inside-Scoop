using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1controllerwithjump : MonoBehaviour {
	//how fast bax moves
	public float topSpeed = 10f;
	//tell where is bax facing direction
	public bool facingRight = true;
	public bool grounded = false;
	public LayerMask groundMask;
	Rigidbody2D myBody;
	Transform myTrans;
	float myWidth, myHeight;
	public float jumpForce = 700f;
	public int jumps = 0;
	public int jumptot = 1;
	public bool canJump = true;

	public float walking = 10f;
	public bool iswalking;
	public float running = 20f;
	public bool wasrunning = false;
	public bool ceiling = true;
	public float move;

	//public float fallMultiplier = 2.5f;
	//public float lowJumpMultiplier = 2.0f;

	Rigidbody2D rb;
	private crouch c;

	private GameMaster gm;
	private SpriteRenderer renderSprite;

	void Awake(){
		rb = GetComponent<Rigidbody2D> ();
		c = GetComponent<crouch> ();
	}

	void Start()
	{
		//anim = GetComponent<Animator>();
		myTrans = this.transform;
		myBody = this.rb;
		BoxCollider2D mySprite = this.GetComponent<BoxCollider2D> ();
		myWidth = mySprite.bounds.extents.x;
		myHeight = mySprite.bounds.extents.y;
		gm = GameObject.FindGameObjectWithTag ("GameMaster").GetComponent<GameMaster>();
		gm.enableabilities ();
		renderSprite = this.GetComponent<SpriteRenderer> ();
	}

	//physics is fixed update
	void FixedUpdate()
	{
		//true or false is hit ground?
		Vector2 myPosition = myTrans.position;
		Vector2 myRight = myTrans.right;
		//Vector2 lineCastPos = myPosition - myRight * myWidth - Vector2.up*myHeight;
		//Vector2 boxCastPos = myPosition - Vector2.up*myHeight;
		if (Input.GetButton ("Move1") && (grounded || wasrunning) && !c.iscrouch) {
			topSpeed = running;
			wasrunning = true;
		} else if (!c.iscrouch){
			topSpeed = walking;
			wasrunning = false;
		}
		Collider2D cg = Physics2D.OverlapArea(new Vector2(myPosition.x-myWidth+0.1f,myPosition.y-myHeight-0.2f),new Vector2(myPosition.x+myWidth-0.1f,myPosition.y-myHeight-0.3f),groundMask);
		if (cg == null||cg.CompareTag ("interact")) {
			grounded = false;
		} else if (!cg.CompareTag ("interact") || cg.CompareTag ("oneway")) {
			grounded = true;

		}
		//grounded = Physics2D.BoxCast (boxCastPos+ Vector2.down*0.1f, new Vector2(myWidth,0.05f),0,new Vector2());
		//Debug.DrawCube (lineCastPos+ Vector2.down*0.1f, lineCastPos + 0.5f*Vector2.down);
		//we are grounded
		//anim.SetBool ("Ground", grounded);
		Collider2D cc = Physics2D.OverlapArea(new Vector2(myPosition.x-myWidth+0.1f,myPosition.y+myHeight),new Vector2(myPosition.x+myWidth-0.1f,myPosition.y+myHeight/2),groundMask);
		if (cc == null||cc.CompareTag ("interact")) {
			ceiling = true;
		} else if (cc.CompareTag ("floor")) {
			ceiling = false;

		}


		//howfast are we moving
		//anim.SetFloat ("vSpeed", rb.velocity.y);

		//get move direction
		move = Input.GetAxis("Horizontal");
		if (Mathf.Abs (move) > 0.01f) {
			iswalking = true;
		} else {
			iswalking = false;
		}

		//add velocity to the rigidbody in the move direction * our speed
		rb.velocity = new Vector2(move * topSpeed, rb.velocity.y);
		/*if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.position += Vector3.left * topSpeed * Time.fixedDeltaTime;
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.position += Vector3.right * topSpeed * Time.fixedDeltaTime;
		}*/
		//anim.SetFloat ("Speed", Mathf.Abs (move));

		//if we're facing the opposite direction, flip
		if (move > 0 && !facingRight) {
			renderSprite.flipX = true;
			facingRight = !facingRight;
		} else if (move < 0 && facingRight) {
			renderSprite.flipX = false;
			facingRight = !facingRight;
		}
	}

	void OnDrawGizmos(){
		Gizmos.DrawCube (new Vector2(transform.position.x, transform.position.y-myHeight-0.25f),new Vector2(2*myWidth,0.01f));
	}

	void Update()
	{
		if (Input.GetButtonDown ("Jump") && (grounded || jumps < jumptot) && canJump) {
			//anim.SetBool ("Ground", false);

			//add jump force to Y asciss ofrigidibody
			rb.velocity= new Vector2(rb.velocity.x,0);
			rb.AddForce (new Vector2 (0, 2 * jumpForce));
			/*if (rb.velocity.y < 0) {
				//rb.velocity= new Vector2(0,0);
				rb.velocity += new Vector2 (0, 2 * jumpForce)* Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
			} else if (rb.velocity.y > 0 && !Input.GetButton ("Jump")) {
				//rb.velocity= new Vector2(0,0);
				rb.velocity += new Vector2 (0, 2 * jumpForce) * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
			}*/

			jumps += 1;
		}

		if (grounded) {
			jumps = 0;
		}
	}

	/*void Flip(){
		//saying we are facing the opposite direction
		facingRight = ! facingRight;

		//get the local scale
		Vector3 theScale = transform.localScale;

		//flip on x axis
		theScale.x *= -1;

		//apply that to the local scale
		transform.localScale = theScale;
	}*/
}
