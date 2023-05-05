using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemGame : MonoBehaviour
{
    //Ser mostrada na HUD
    public static int coinTotal; // uma variável pública e estática: A roupa na vitrine.

    static int smallCoin = 50; //estática, não é visível nem alterável em outros Scripts


    public static int AddCoin() //Método que adiciona smallCoin á totalCoin;
    {
        return coinTotal += smallCoin; 
    }
}
