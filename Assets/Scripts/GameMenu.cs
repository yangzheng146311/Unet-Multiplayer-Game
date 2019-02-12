using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
public class GameMenu : MonoBehaviour{


    GameObject winText;
    GameObject loseText;
    GameObject backBtn;
    // Use this for initialization
    void Awake () {

        
            winText = GameObject.Find("Win_Txt");
            winText.SetActive(false);

            loseText = GameObject.Find("Lose_Txt");
            loseText.SetActive(false);

            backBtn = GameObject.Find("Back_Btn");
            backBtn.SetActive(false);
        
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public  void  EnableWinTips()
    {
       //if(isLocalPlayer)
        winText.SetActive(true);
        backBtn.SetActive(true);

    }

    public void EnableLoseTips()
    {
       // if (isLocalPlayer)
        loseText.SetActive(true);
        backBtn.SetActive(true);
    }

    public void JumpToStartMenu()
    {

        SceneManager.LoadScene("Menu");

    }


}
