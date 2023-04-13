using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //Este código está no personagem

    GameObject playerObj;// variável do objeto do jogador
    GameObject cameraObj;// variável do objeto da câmera

    float mouseX, mouseY; // variável do eixo dos mouses

    [SerializeField]
    float speedRotation; // velocidade de rotação
   
    void Start()
    {
        playerObj = GetComponent<GameObject>();//atribuição da variável
        cameraObj = GameObject.Find("Main Camera");//atribuição da variável
        //cameraObj = GetComponentInChildren<GameObject>();

        //speedRotation = 300f;
        
    }


    void Update()
    {
        //Altera o moto do cursor para trancado no meio da câmera
        Cursor.lockState = CursorLockMode.Locked;
        
        //Deixa o cursor invisível
        //Cursor.visible = false;

        //Movimento do mouse em relação aos eixos(Axis)
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        gameObject.transform.Rotate(Vector3.up * mouseX * Time.deltaTime * (speedRotation/2));
        #region comentários do rotate
        //Usando função Rotate
        //Vector3.up = new Vector(1,0,0); // gire no Y
        //mouseX = -1 a 1; // lado que ele vai girar
        //Time.deltaTime //equivalência
        //speedRotation = velocidade de rotação
        #endregion

        //cameraObj.transform.Rotate(Vector3.right * mouseY * Time.deltaTime * speedRotation);

    }
}
