using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshEnemy : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    GameObject playerObj;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        playerObj = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.SetDestination(playerObj.transform.position);
    }
}
