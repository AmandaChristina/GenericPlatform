using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField]
    Vector3 posCurrent, posNew;
    [SerializeField]
    float speed, count;
    [SerializeField]
    bool isDown;


    void Start()
    {
        count = 6f;
        //isDown = true;
    }

    void Update()
    {
        count = count - Time.deltaTime;
       
        if (count <= 0f)
        {
            count = 6f;
            isDown = !isDown;
        }
        

        //descer
        if (transform.position.y >= posCurrent.y && isDown)
        {
           
            transform.position = Vector3.Lerp(transform.position, posNew, Time.deltaTime * speed);

        }

        //Senão
        else if (transform.position.y <= posNew.y && !isDown)
        {
            transform.position = Vector3.Lerp(transform.position, posCurrent, Time.deltaTime * speed);
        }

        #region teste
        //if (transform.position.y >= 0.1) 
        //{
        //    transform.Translate(-Vector3.up * 0.3f);

        //}

        //else if (transform.position.y <= 3.5f)
        //{
        //    transform.Translate(Vector3.up * 0.3f);
        //}
        #endregion

    }

    
}
