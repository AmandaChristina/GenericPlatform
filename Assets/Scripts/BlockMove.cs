using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMove : MonoBehaviour
{
    Vector3 initialPosition, nextPosition, currentPosition;
    [SerializeField] float speedMovement;
    float timeInterpolate = 0.05f;
    [SerializeField] float distanceBetweenPositions;
    [SerializeField] bool isNext = true;
    [SerializeField] Vector3 distance;

    // Start is called before the first frame update
    private void Awake()
    {
        initialPosition = transform.position;

    }

    void Start()
    {
        
        nextPosition = new Vector3(initialPosition.x + distance.x, initialPosition.y + distance.y, initialPosition.z + distance.z);

    }

    // Update is called once per frame
    void Update()
    {
        //Debug Var
        distanceBetweenPositions = Vector3.Distance(transform.position, currentPosition);

        transform.position = Vector3.Lerp(transform.position, currentPosition, timeInterpolate * speedMovement);

        if (distanceBetweenPositions < 1f)
        { 
            isNext = !isNext;
        }


        if (isNext) currentPosition = nextPosition;
        else currentPosition = initialPosition;


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) other.transform.parent = transform;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) other.transform.parent = null;
    }
}
