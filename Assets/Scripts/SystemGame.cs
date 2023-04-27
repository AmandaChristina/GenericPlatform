using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemGame : MonoBehaviour
{
    public static int coin;
    static int smallCoin = 50;

    public static int Coin()
    {
        return coin += smallCoin; 
    }
}
