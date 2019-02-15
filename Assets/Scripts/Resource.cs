using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Resource : MonoBehaviour {

    
    GameObject attachObject;
    GameManager gM;




    private void Awake()
    {
        gM = GameObject.FindObjectOfType<GameManager>();
    }
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



        //if (collision.gameObject.tag.Equals("Player"))
        //{
          
        //    transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

        //    if(transform.GetComponent<MeshCollider>())   Destroy(transform.GetComponent<MeshCollider>());

        //    transform.SetParent(collision.transform);


        //}
    }

 


}
