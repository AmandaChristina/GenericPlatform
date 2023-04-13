using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //Este c�digo est� no personagem

    GameObject playerObj;// vari�vel do objeto do jogador
    GameObject cameraObj;// vari�vel do objeto da c�mera

    float mouseX, mouseY; // vari�vel do eixo dos mouses

    [SerializeField]
    float speedRotation; // velocidade de rota��o
   
    void Start()
    {
        playerObj = GetComponent<GameObject>();//atribui��o da vari�vel
        cameraObj = GameObject.Find("Main Camera");//atribui��o da vari�vel
        //cameraObj = GetComponentInChildren<GameObject>();

        //speedRotation = 300f;
        
    }


    void Update()
    {
        //Altera o moto do cursor para trancado no meio da c�mera
        Cursor.lockState = CursorLockMode.Locked;
        
        //Deixa o cursor invis�vel
        //Cursor.visible = false;

        //Movimento do mouse em rela��o aos eixos(Axis)
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        gameObject.transform.Rotate(Vector3.up * mouseX * Time.deltaTime * (speedRotation/2));
        #region coment�rios do rotate
        //Usando fun��o Rotate
        //Vector3.up = new Vector(1,0,0); // gire no Y
        //mouseX = -1 a 1; // lado que ele vai girar
        //Time.deltaTime //equival�ncia
        //speedRotation = velocidade de rota��o
        #endregion

        //cameraObj.transform.Rotate(Vector3.right * mouseY * Time.deltaTime * speedRotation);

    }
}
