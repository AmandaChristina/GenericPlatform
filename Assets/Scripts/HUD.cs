using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    static TextMeshProUGUI debugText;
    TextMeshProUGUI coinText;

    void Start()
    {
        debugText = GameObject.Find("Debug").GetComponent<TextMeshProUGUI>();
        coinText = GameObject.Find("CoinText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = SystemGame.coinTotal.ToString();
    }

    //Método = Functions
    //public static = Manequins em vitrines: todo mundo vê, mas ninguém toca
    public static void DebugText(string nameObj)
    {
         debugText.text = nameObj;
    }
}
