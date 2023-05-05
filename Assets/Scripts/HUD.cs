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

    //M�todo = Functions
    //public static = Manequins em vitrines: todo mundo v�, mas ningu�m toca
    public static void DebugText(string nameObj)
    {
         debugText.text = nameObj;
    }
}
