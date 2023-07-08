using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //Biblioteca do NavMesh

public class NavMeshEnemy : MonoBehaviour
{
    //LOCAL DAS VARIÁVEIS

    NavMeshAgent navMeshAgent;  //guardar o componente do inimigo
    GameObject playerObj;   //VAI  guardar o objeto Jogador


    [SerializeField]    // deixar visível a variável abaixo
    Transform[] waypoint;   //Isso aqui é um array
    float distancePlayer, distanceWaypoint;  //Guardar distâncias
    public int contadorWaypoints;       //Conta o objetivo do inimigo

    void Start()
    {
        //Atribuindo variável -> Colocando as coisas dentro
        navMeshAgent = GetComponent<NavMeshAgent>(); //Enfiando componente inimigo
        playerObj = GameObject.Find("Player"); //Enfiando o Objeto Jogador
    }

    // Update is called once per frame
    void Update()
    {
        //distancia entre o inimigo e o jogador
        distancePlayer = Vector3.Distance(playerObj.transform.position, transform.position);
        distanceWaypoint = Vector3.Distance(navMeshAgent.destination, transform.position);

        //Se não chegou ao máximo de waypoints e ta perto dele
        if (contadorWaypoints < waypoint.Length && distanceWaypoint < 1.6f)
        {
            contadorWaypoints++; //vai pro próximo
        }
        //Agora se chegou no máximo de waypoints, volta pro primeiro
        else if (contadorWaypoints == waypoint.Length) contadorWaypoints = 0;

        //Atualiza o objetivo do inimigo
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
