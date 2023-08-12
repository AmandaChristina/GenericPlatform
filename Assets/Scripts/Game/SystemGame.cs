using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEditor;

public class SystemGame : MonoBehaviour
{
    public static Scene scene;
    static AudioSource soundCoin;

    //Ser mostrada na HUD
    public static int coinTotal; // uma vari�vel p�blica e est�tica: A roupa na vitrine.

    static int smallCoin = 50; //est�tica, n�o � vis�vel nem alter�vel em outros Scripts

    public static int vida = 3;
    public static bool moveState = true;

    void Start()
    {
        scene = SceneManager.GetActiveScene();
        soundCoin = GetComponent<AudioSource>();


    }

    void Update()
    {
        if(vida <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public static int AddCoin() //M�todo que adiciona smallCoin � totalCoin;
    {
        soundCoin.Play();
        return coinTotal += smallCoin; 
    }

    public static void FallingLife()
    {
        if(vida > 0)
        {
            vida--;
            coinTotal = 0;
            SceneManager.LoadScene(scene.name);
        }
    }

    public static void DamageLife()
    {
        if (vida > 0) vida--;

        BlockMovePlayer();
    }

    public static IEnumerator BlockMovePlayer()
    {
        moveState = false;
        yield return new WaitForSeconds(2f);
        moveState = true;
    }

}
