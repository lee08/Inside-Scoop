using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class Waypoint : MonoBehaviour {
	[System.Serializable]
	public class MyEventType : UnityEvent { }

	public MyEventType OnEvent;

}