using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class audioplayer: MonoBehaviour
{
	public AudioSource audioSourceIntro;
	public AudioSource audioSourceLoop;
	private bool startedLoop;
	void Awake(){
		audioSourceIntro.Play();
	}
	void FixedUpdate()
	{
		if (!audioSourceIntro.isPlaying && !startedLoop)
		{
			audioSourceLoop.Play();
			Debug.Log("Done playing");
			startedLoop = true;
		}
	}
}