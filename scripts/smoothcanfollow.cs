using UnityEngine;

public class smoothcanfollow : MonoBehaviour {
	public Transform target;

	public float smoothSpeed = 0.125f;

	public Vector3 offset;

	void FixedUpdate(){
		Vector3 desiredposition = target.position + offset;
		Vector3 smoothedposition = Vector3.Lerp (transform.position, desiredposition, smoothSpeed);
			
		transform.position = smoothedposition;

		//transform.LookAt (target);
	}


}
