using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class SystemGame : MonoBehaviour
{



    //Ser mostrada na HUD
    public static int coinTotal; // uma vari�vel p�blica e est�tica: A roupa na vitrine.

    static int smallCoin = 50; //est�tica, n�o � vis�vel nem alter�vel em outros Scripts

    public static int vida = 3;


    public static int AddCoin(AudioSource soundCoin) //M�todo que adiciona smallCoin � totalCoin;
    {
        soundCoin.Play();
        return coinTotal += smallCoin; 
    }

    public static void LostLife()
    {
        if(vida > 0)
        {
            vida--;
            coinTotal = 0;
            SceneManager.LoadScene("Fase1");
        }else{
            SceneManager.LoadScene("GameOver");
        }

        print(vida);
    }

}
