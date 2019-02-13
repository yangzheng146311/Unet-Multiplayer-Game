using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
public class GameManager:NetworkBehaviour{

    const float MAXTIME = 30.0f;

    [SyncVar]
    float curTime = MAXTIME;

    //[SyncVar]
    int winnerIndex = -1;

   // [SyncVar]
    int maxScore;

    GameObject timeText;

    GameObject[] players;

    [SyncVar]
    public bool gameOn = false;

    

  



    void Start()
    {

        timeText = GameObject.Find("Time_text");

    }


    void Update()
    {
        if (isServer&&gameOn)
        {
            CountDown();
        }
         
         
        timeText.GetComponent<Text>().text = "Time:" + ((int)curTime).ToString();
        

        
        UpdateCurrentWinner();



       

    }


  
    private void CountDown()
    {
        if (curTime > 0)
        {
            //Debug.Log(curTime);
            curTime-= Time.deltaTime;
        }
       
    }

   //[Command]
    private void UpdateCurrentWinner()
    {


        players = GameObject.FindGameObjectsWithTag("Player");

        //Debug.Log("length="+players.Length);
         maxScore = 0;

        for (int i = 0; i <players.Length; i++)
        {
            players[i].GetComponent<PlayerBall>().PlayerIndex = i;


            //Debug.Log("Player Num " + i + "score=" + players[i].GetComponent<PlayerBall>().Score);

            if(players[i].GetComponent<PlayerBall>().Score > maxScore)
            {

                maxScore = players[i].GetComponent<PlayerBall>().Score;
                winnerIndex = players[i].GetComponent<PlayerBall>().PlayerIndex;

            }

        }

       // Debug.Log("maxScore="+maxScore);
       // Debug.Log("winnerIndex="+winnerIndex);


    }




    public int WinnerIndex
    {
        get
        {

            return winnerIndex;

        }


    }

    public float CurTime
    {

        get
        {

            return curTime;

        }


    }
}
