using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class ResSpawner : NetworkBehaviour
{

    public GameObject resPrefab;
    public int numberOfRes;


    public override void OnStartServer()
    {
        for (int i = 0; i < numberOfRes; i++)
        {
            Vector3 position = new Vector3(Random.Range(-20f, 20f), 1, Random.Range(-20f, 20f));

            Quaternion rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);

            GameObject res = Instantiate(resPrefab, position, rotation) as GameObject;

            NetworkServer.Spawn(res);
        }
    }


    //private void Update()
    //{
    //    if(Input.GetKeyDown(KeyCode.O))
    //    {
    //        CmdGenertateResources();

    //    }
    //}



    //[Command]
    //void CmdGenertateResources()
    //{

       

    //}
}
