using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources : MonoBehaviour {

    //bool isAttached = false;
    GameObject attachObject;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //if (attachObject != null)
        //{
        //    Vector3 forceDir = (attachObject.transform.position - transform.position).normalized;
        //    gameObject.transform.GetComponent<Rigidbody>().AddForce(forceDir * 20.0f);


        //}
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            //transform.SetParent(collision.transform);
            //transform.SetParent(collision.transform);
            //transform.GetComponent<Rigidbody>().useGravity = false;
            //collision.transform.GetComponent<BoxCollider>().isTrigger = true;
            // Destroy(collision.transform.GetComponent<Rigidbody>());
            //collision.transform.SetParent(transform);
            //collision.transform.localPosition = Vector3.zero;


            //collision.transform.GetComponent<Rigidbody>().AddForce((transform.position - collision.transform.position).normalized * 10.0f);
            //collision.transform.SetParent(transform);


            Destroy(transform.GetComponent<Rigidbody>());
            Destroy(transform.GetComponent<BoxCollider>());
            //isAttached = true;
           // Vector3 forceDir = (collision.transform.position - transform.position).normalized;
            //gameObject.transform.GetComponent<Rigidbody>().AddForce(forceDir * 20.0f);
            ////attachObject = collision.gameObject;
            transform.SetParent(collision.transform);


           




        }
    }




}
