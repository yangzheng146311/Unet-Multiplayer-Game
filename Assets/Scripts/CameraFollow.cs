using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform player;
    public float rotateSpeed=10.0f;
    Vector3 distanceVec;

    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;
   
    // Use this for initialization
    void Start () {

       // if (player)
           // distanceVec = transform.position - player.transform.position;
        distanceVec = new Vector3(0, 10, -10);
        //transform.SetParent(null);
    }
	
	// Update is called once per frame
	void Update () {
        //GameObject thePlayer = GameObject.FindGameObjectWithTag("Player");
        //if(thePlayer!=null)
        //{

        //    player = thePlayer.transform;

        //}
    }
    
    void LateUpdate() //对摄像机的操作写在LateUpdate里
    {
        if (player)
        {
            if (Input.GetKey(KeyCode.Mouse1))
            {
                Quaternion camTurnAngleX = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotateSpeed, Vector3.up);
                Quaternion camTurnAngleY = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * rotateSpeed, Vector3.left);


                distanceVec =  camTurnAngleX * camTurnAngleY* distanceVec;
            }


            Vector3 newPos = player.transform.position + distanceVec;
            transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);
            transform.LookAt(player.transform);
        }


    }
        
    

}
