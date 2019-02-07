using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class PlayerBall : NetworkBehaviour
{


    public float speed=10.0f;
    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        //rb
        rb = GetComponent<Rigidbody>();

        
    }





    private void Update()
    {
       // CastObject();
    }

    public override void OnStartLocalPlayer()
    {
        //这个方法只会在本地角色那里调用  当角色被创建的时候
        GetComponent<MeshRenderer>().material.color = Color.blue;
        

        Camera.main.GetComponent<CameraFollow>().player = transform;
        
    

    }
    void FixedUpdate()
    {

        if (isLocalPlayer == false)
        {
            return;
        }
        //Camera.main.transform.LookAt(transform.position);
        //Camera.main.transform.position = transform.position + new Vector3(0, 10, -10);
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");

        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        //Vector3 movement=(transform.position-Camera.main.transform.position).normalized*moveHorizontal * moveVertical;


        Vector3 dirMove = (transform.position - Camera.main.transform.position).normalized;
        Vector3 dirTurn = Vector3.Cross(dirMove, Vector3.up).normalized;

        if(Input.GetKey(KeyCode.W))
        {

            rb.AddForce(dirMove * speed);

        }

        if (Input.GetKey(KeyCode.Space))
        {

            rb.AddForce(dirMove * speed * 100.0f);

        }
        if (Input.GetKey(KeyCode.S))
        {

            rb.AddForce(-dirMove * speed);

        }

        if (Input.GetKey(KeyCode.A))
        {

            rb.AddForce(dirTurn * speed);

        }

        if (Input.GetKey(KeyCode.D))
        {

            rb.AddForce(-dirTurn * speed);

        }




        //rb.AddForce(movement * speed);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("res"))
        {

            //collision.transform.GetComponent<BoxCollider>().isTrigger = true;
            //Destroy(collision.transform.GetComponent<Rigidbody>());
            //collision.transform.SetParent(transform);
            //collision.transform.localPosition = Vector3.zero;


            //collision.transform.GetComponent<Rigidbody>().AddForce((transform.position - collision.transform.position).normalized * 10.0f);
            //collision.transform.SetParent(transform);



        }
    }


    private void CastObject()
    {

        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    Transform child = transform.GetChild(0);
        //    child.SetParent(null);
        //    Vector3 vDir = gameObject.GetComponent<Rigidbody>().velocity.normalized;
        //    child.gameObject.AddComponent<Rigidbody>();
        //    child.GetComponent<Rigidbody>().AddForce(vDir * 10.0f);
        //    //child.gameObject.AddComponent<Rigidbody>();
           
        //    //child.gameObject.GetComponent<Rigidbody>().AddForce(forwardWorld* 100.0f);
          


        //}

    }

}
