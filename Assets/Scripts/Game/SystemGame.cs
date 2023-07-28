using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class SystemGame : MonoBehaviour
{
    public static Scene scene;
    static AudioSource soundCoin;

    //Ser mostrada na HUD
    public static int coinTotal; // uma variável pública e estática: A roupa na vitrine.

    static int smallCoin = 50; //estática, não é visível nem alterável em outros Scripts

    public static int vida = 3;

    void Start()
    {
        scene = SceneManager.GetActiveScene();
        soundCoin = GetComponent<AudioSource>();


    }

    public static int AddCoin() //Método que adiciona smallCoin á totalCoin;
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
            SceneManager.LoadScene(scene.name);
        }else{
            SceneManager.LoadScene("GameOver");
        }

        print(vida);
    }

}
