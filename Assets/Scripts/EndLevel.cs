using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            //Ativar uma música
            //Colocar um efeito de branqueamento da tela.
            SceneManager.LoadScene("Menu");
        }
    }
}
