using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

    public GameObject bulletPrefab;
    public Transform bulletSpawn;



    private void Start()
    {
       
      
    }

    // Update is called once per frame
    void Update () {

        if (isLocalPlayer == false)
        {
            return;
        }
        Camera.main.transform.LookAt(transform.position);
        Camera.main.transform.position = transform.position + new Vector3(0, 10, -10);




        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.up * h * 120 * Time.deltaTime);
        transform.Translate(Vector3.forward * v * 3 * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CmdFire();
        }
	}


    public override void OnStartLocalPlayer()
    {
        //这个方法只会在本地角色那里调用  当角色被创建的时候
        GetComponent<MeshRenderer>().material.color = Color.blue;
    }


    [Command]// called in client, run in server
    void CmdFire()//这个方法需要在server里面调用
    {
        // 子弹的生成 需要server完成，然后把子弹同步到各个client
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation) as GameObject;
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 10;
        Destroy(bullet, 2);

        NetworkServer.Spawn(bullet);
    }


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("111111111111111");
        if (collision.gameObject.tag.Equals("res"))
        {
            Destroy(collision.gameObject);

        }
    }
}
