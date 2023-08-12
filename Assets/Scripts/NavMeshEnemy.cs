using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //Biblioteca do NavMesh

public class NavMeshEnemy : MonoBehaviour
{
    //LOCAL DAS VARI�VEIS

    NavMeshAgent navMeshAgent;  //guardar o componente do inimigo
    GameObject playerObj;   //VAI  guardar o objeto Jogador


    [SerializeField]    // deixar vis�vel a vari�vel abaixo
    Transform[] waypoint;   //Isso aqui � um array
    float distancePlayer, distanceWaypoint;  //Guardar dist�ncias
    public int contadorWaypoints;       //Conta o objetivo do inimigo

    void Start()
    {
        //Atribuindo vari�vel -> Colocando as coisas dentro
        navMeshAgent = GetComponent<NavMeshAgent>(); //Enfiando componente inimigo
        playerObj = GameObject.Find("Player"); //Enfiando o Objeto Jogador
    }

    // Update is called once per frame
    void Update()
    {
        #region behavior
        //distancia entre o inimigo e o jogador
        distancePlayer = Vector3.Distance(playerObj.transform.position, transform.position);

        //Verifica se o Player est� perto
        if (distancePlayer < 10f) FollowPlayer();

        //Caso n�o, volte a patrulhar
        else Patrol();
        #endregion 


    }

    void Patrol()
    {
        //seta o destido do agente no inicio do c�digo
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

        //Lembrando que tem que parar a anima��o depois
        if (distancePlayer < 2.5f)
        {
            RotationToPlayer();
            navMeshAgent.isStopped = true;
        }
        else navMeshAgent.isStopped = false;

        navMeshAgent.SetDestination(playerObj.transform.position);


    }

    void RotationToPlayer()
    {
        //Pelo que entendi a diferen�a entre os dois se d� por um � focado em rotation, j� o outro muda todo o transform e rotation para um objeto, mas n�o tenho certeza 

        Vector3 positionTo = playerObj.transform.position - transform.position;
        Quaternion rotationTo = Quaternion.LookRotation(positionTo, Vector3.up);
        transform.rotation = rotationTo;

        //With LookAt
        //transform.LookAt(playerObj.transform);
    }

  
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SystemGame.DamageLife();
        }
        
    }

}
