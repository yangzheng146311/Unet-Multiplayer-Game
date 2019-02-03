using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform player;
    public float rotateSpeed;
    Vector3 distanceVec;

    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;
   
    // Use this for initialization
    void Start () {


        distanceVec = transform.position - player.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void LateUpdate() //对摄像机的操作写在LateUpdate里
    {
        Quaternion camTurnAngleX = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotateSpeed, Vector3.up);
        Quaternion camTurnAngleY = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * rotateSpeed, Vector3.left);

        distanceVec = camTurnAngleX*camTurnAngleY * distanceVec;


        Vector3 newPos = player.transform.position + distanceVec;
        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);
        transform.LookAt(player.transform);

    }
        
    

}
