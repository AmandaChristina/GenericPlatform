using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemGame : MonoBehaviour
{
    //Ser mostrada na HUD
    public static int coinTotal; // uma vari�vel p�blica e est�tica: A roupa na vitrine.

    static int smallCoin = 50; //est�tica, n�o � vis�vel nem alter�vel em outros Scripts


    public static int AddCoin() //M�todo que adiciona smallCoin � totalCoin;
    {
        return coinTotal += smallCoin; 
    }
}
