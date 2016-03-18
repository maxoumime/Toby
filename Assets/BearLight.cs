using UnityEngine;
using System.Collections;

public class BearLight : MonoBehaviour {

	public Light light;
	public AudioClip audio;

	// Use this for initialization
	void Start () {
		//light.intensity = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.A) && !light.isActiveAndEnabled) {
			StartCoroutine(Example());
			GetComponent<AudioSource> ().PlayOneShot (audio);
		}
	}

	IEnumerator Example() {
		light.enabled = true;
		yield return new WaitForSeconds(3);
		light.enabled = false;
	}
}
