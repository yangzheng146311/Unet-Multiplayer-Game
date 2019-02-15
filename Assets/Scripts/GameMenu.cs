using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
public class GameMenu : NetworkBehaviour{


    
    GameManager gM;

    public GameObject winText;
    public GameObject loseText;
    public GameObject backBtn;
    public GameObject startBtn;
    // Use this for initialization
    void Awake () {

        
            //winText = GameObject.Find("Win_Txt");
            winText.SetActive(false);

           // loseText = GameObject.Find("Lose_Txt");
            loseText.SetActive(false);

            //backBtn = GameObject.Find("Back_Btn");
            backBtn.SetActive(false);

            startBtn.SetActive(false);






        gM = GameObject.FindObjectOfType<GameManager>();
        
        
    }


    public override void OnStartServer()
    {
        startBtn.SetActive(true);
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



   
    public void StartTheGame()
    {

       
           
        startBtn.SetActive(false);
       
        
        gM.gameOn = true;

    }

}
