using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour {

	void OnTriggerEnter(Collider other) {

		Time.timeScale = 0f;//Le temps s'arrête

		GUI.TextArea(new Rect(Screen.width/2 - 40, Screen.height/2 - 20, 80, 40),
			"Hihihi vous avez fini le trial. PAYEZ ou MOURREZ !");
		if (GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height / 2 + 20, 80, 40), "Quitter"))
		{
			SceneManager.LoadScene("Menu");
		}
	}
}
