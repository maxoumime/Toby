using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

	public AudioClip sound;
	public bool ChargerScene { get; set; }
	public void LOAD_SCENE()
	{
		gameObject.AddComponent<AudioSource>();
		audioSource.clip = sound;
		audioSource.playOnAwake = false;
		audioSource.PlayOneShot(sound);
		ChargerScene = true;
	}

	private void Update()
	{
		if (ChargerScene == true && !audioSource.isPlaying)
		{
			SceneManager.LoadScene("Levels/Jeu");
		}
	}

	private AudioSource audioSource
	{
		get { return GetComponent<AudioSource>(); }
	}



	public void QUIT()
	{
		Application.Quit();
	}
}
