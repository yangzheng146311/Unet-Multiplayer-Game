using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.AI;
using System;

public class Health : NetworkBehaviour {


    public const int maxHealth = 100;
    [SyncVar(hook="OnChangeHealth") ]
    public int currentHealth = maxHealth;
    public Slider healthSlider;
    public bool destroyOnDeath = false;
    

    private NetworkStartPosition[] spawnPoints;


    [SerializeField]
    GameObject [] target;
    GameObject curTar;

    NavMeshAgent agent;

    float minDis;
    int closestTarIndex = -1;

    void Start()
    {
        if (isLocalPlayer)
        {
            spawnPoints = FindObjectsOfType<NetworkStartPosition>();
        }

       
    }

    void Update()
    {
        target = GameObject.FindGameObjectsWithTag("Player");
        minDis = 9999;
        for (int i = 0; i < target.Length; i++)
        {
            Vector3 disV = transform.position - target[i].transform.position;
            float dis = disV.magnitude;
            if (dis < minDis)
            {
                minDis = dis;
                closestTarIndex = i;
                curTar = target[i];


            }
        }

        agent = gameObject.GetComponent<NavMeshAgent>();
        if (!agent) Debug.Log("No agent");
        else
            SetDestination();

    }

    private void SetDestination()
    {
        if(curTar)
        agent.SetDestination(curTar.gameObject.transform.position);
    }

    public void TakeDamage(int damage)
    {

        if (isServer == false) return;// 血量的处理只在服务器端执行

        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            if (destroyOnDeath)
            {
                Destroy(this.gameObject); return;
            }

            currentHealth = maxHealth;
            Debug.Log("Dead");
            RpcRespawn();
        }

    }
    void OnChangeHealth(int health)
    {
        healthSlider.value = health / (float)maxHealth;
    }

    [ClientRpc]
    void RpcRespawn()
    {
        if (isLocalPlayer == false) return;

        Vector3 spawnPosition = Vector3.zero;

        if (spawnPoints != null && spawnPoints.Length > 0)
        {
            spawnPosition = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)].transform.position;
        }


        transform.position = spawnPosition;
    }
}
