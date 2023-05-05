using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField]
    float distance = 500f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distance))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * distance, Color.red);

            HUD.DebugText(hit.transform.name);

            if (hit.transform.tag == "Coin")
            {
                SystemGame.AddCoin();
                Destroy(hit.transform.gameObject);
            }

        }
    }
}
