using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    static TextMeshProUGUI debugText;
    TextMeshProUGUI coinText, lifeText;

    void Start()
    {
        debugText = GameObject.Find("Debug").GetComponent<TextMeshProUGUI>();
        coinText = GameObject.Find("CoinText").GetComponent<TextMeshProUGUI>();
        lifeText = GameObject.Find("VidaText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        lifeText.text = "Vida: " + SystemGame.vida;
        coinText.text = "Moeda: " + SystemGame.coinTotal;
    }

    //Método = Functions
    //public static = Manequins em vitrines: todo mundo vê, mas ninguém toca
    public static void DebugText(string nameObj)
    {
         debugText.text = nameObj;
    }
}
