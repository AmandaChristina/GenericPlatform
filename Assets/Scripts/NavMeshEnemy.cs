using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshEnemy : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    GameObject playerObj;


    [SerializeField]
    Transform[] waypoint;
    float distancePlayer, distanceWaypoint;
    public int contadorWaypoints;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        playerObj = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //distancia entre o inimigo e o jogador
        distancePlayer = Vector3.Distance(playerObj.transform.position, transform.position);
        distanceWaypoint = Vector3.Distance(navMeshAgent.destination, transform.position);


        if (contadorWaypoints < waypoint.Length && distanceWaypoint < 1.6f)
        {
            contadorWaypoints++;
        }
        else if (contadorWaypoints == waypoint.Length) contadorWaypoints = 0;


        navMeshAgent.SetDestination(waypoint[contadorWaypoints].position);




    }

    void FollowPlayer()
    {
        if (distancePlayer < 10f)
        {
            navMeshAgent.SetDestination(playerObj.transform.position);
        }
    }
}
