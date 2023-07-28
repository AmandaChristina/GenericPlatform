using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{

    [SerializeField] string nameScene;
    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //Ativar uma música
            //Colocar um efeito de branqueamento da tela.
            SceneManager.LoadScene(nameScene);
        }
    }
}
