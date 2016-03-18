using UnityEngine;
using System.Collections;

public class CreepyMusic : MonoBehaviour {

	public AudioClip music;

	public void Start(){
		GetComponent<AudioSource>().PlayOneShot(music);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
