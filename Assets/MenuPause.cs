using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour {

    public bool IsPaused { get; set; }
    public bool FinDutrial ;
    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            IsPaused = !IsPaused;
        }

        if (IsPaused)
        {
            Time.timeScale = 0f;//Le temps s'arrête
        }
        else
        {
            Time.timeScale = 1.0f; // Le temps reprend
        }
    }

    public void OnGUI()
    {
        GUI.TextArea(new Rect(Screen.width - 300, Screen.height - 100, 300, 100),
                "Fouiller le campement."+Environment.NewLine+ "Trouver la cabane.");
        Component[] cs = (Component[])gameObject.GetComponents(typeof(Component));
        Component player = new Component();
        Component cabane = new Component(); 
        foreach (Component c in cs)
        {
            Debug.Log("name " + c.name + " type " + c.GetType() + " basetype " + c.GetType().BaseType);
            if (c.name == "Wooden Hut")
                cabane = c;
            if (c.name == "Player")
                player = c;
        }
        float distance = 10000;
        if(player != null && player.transform != null && player.transform.position != null &&
            cabane != null && cabane.transform != null && cabane.transform.position != null)
                distance = Vector3.Distance(player.transform.position, cabane.transform.position);

		if (distance < 1)
        {
            FinDutrial = true;
        }

        if (FinDutrial)
        {
            GUI.TextArea(new Rect(Screen.width/2 - 40, Screen.height/2 - 20, 80, 40),
                "Hihihi vous avez fini le trial. PAYEZ ou MOURREZ !");
            if (GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height / 2 + 20, 80, 40), "Quitter"))
            {
                SceneManager.LoadScene("Menu");
            }
        }
        if (IsPaused)
        {
            if (GUI.Button(new Rect(Screen.width/2 - 40, Screen.height/2 - 20, 80, 40), "Continuer"))
            {
                IsPaused = false;
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height / 2 + 20, 80, 40), "Quitter"))
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }
}
