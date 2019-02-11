using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void JumpToMain()
    {
        Debug.Log("go to main");
        SceneManager.LoadScene("main");
        

    }

    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();

    }
}
