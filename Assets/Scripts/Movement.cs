using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Movement : MonoBehaviour
{
    CharacterController player;
    Vector3 move;
    Vector3 velocity;

    [SerializeField]//mostra o campo abaixo no inspetor
    float speed;
    float moveX, moveZ;
    float gravity = -9.81f;
    float jumpHeight = 0.3f;
    [SerializeField]
    bool grounded;

    //Animations
    [SerializeField]
    Animator playerAnimator;
    [SerializeField]
    bool isJumping, isJump;
    public Animation playerAnimation;


    //Configs Iniciais
    void Start()
    {
        //Player do tipo Character Controller
        player = GetComponent<CharacterController>();
        playerAnimator = GetComponentInChildren<Animator>();
    }


    void Update()
    {
        MovePlayer();
        Jump();
        AnimationMethod();
    }

    void MovePlayer()
    {
        //Inputs 
        //WASD; Setas; Joystick;
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");

        //Atribui a uma variável vector3
        //Normalized: Personagem não andar rápido em diagonal 
        //move = new Vector3(moveX, velocity.y, moveZ).normalized;
        move = new Vector3(moveX, velocity.y, moveZ);
        move = transform.TransformDirection(move);

        //Função do Character Controller: Move
        player.Move(move * Time.deltaTime * speed);

    }
    //void Jump()
    //{
    //    grounded = player.isGrounded;

    //    //zerando velocity
    //    if (player.isGrounded && velocity.y < 0f)
    //    {
    //        velocity.y = 0f;
    //    }

    //    //descendo
    //    velocity.y += gravity * Time.deltaTime;
    //    //subindo
    //    if (Input.GetButtonDown("Jump") && player.isGrounded)
    //    {
    //        //Retorna a raiz quadrada
    //        velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
    //    }

    //    //aplicando movimento
    //    //player.Move(velocity * Time.deltaTime);
    //}
   void Jump()
    {
        grounded = player.isGrounded;

        //zerando velocity
        if (player.isGrounded && velocity.y < 0f)
        {
            isJump = false;
            velocity.y = 0f;
        }

        //descendo
        velocity.y += gravity * Time.deltaTime;
        
        //subindo
        if (Input.GetButtonDown("Jump") && player.isGrounded && !isJump)
        {
            isJump = true;
            //Retorna a raiz quadrada
            velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }

        //aplicando movimento
        //player.Move(velocity * Time.deltaTime);
    }

    void AnimationMethod()
    {
        playerAnimator.SetBool("isJump", isJump);

        if (Input.GetKeyDown(KeyCode.E)) playerAnimator.Play("Chicken Dance");

        //print(playerAnimator.GetBool("isJump"));

        if (player.velocity.z != 0 || player.velocity.x != 0)
        {
            playerAnimator.SetBool("isWalking", true);

        }

        else if(player.velocity.z == 0 && player.velocity.x == 0)
        {
            playerAnimator.SetBool("isWalking", false);

        }
        
    }
}
