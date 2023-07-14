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

        //Verifica se o Player está perto
        if (distancePlayer < 5f) FollowPlayer();

        //Caso não, volte a patrulhar
        else Patrol();

    }
   
    void Patrol()
    {
        //seta o destido do agente no inicio do código
        navMeshAgent.SetDestination(waypoint[contadorWaypoints].position);

        //distancia entre o inimigo e o destido
        distanceWaypoint = Vector3.Distance(navMeshAgent.destination, transform.position);

        //verificando se chegou no waypoint
        //Lembrando 
        if (distanceWaypoint < 1.2f)
        {
            contadorWaypoints++;//continua contando

            //se o contador de waypoints passa do limite da Index
            if (contadorWaypoints == waypoint.Length)
            {
                //zera a contagem
                contadorWaypoints = 0;
            }
        }
    }

    void FollowPlayer()
    {

        navMeshAgent.SetDestination(playerObj.transform.position);
        
    }
}
