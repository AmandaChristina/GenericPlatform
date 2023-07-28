using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMove : MonoBehaviour
{
    Vector3 initialPosition, nextPosition, currentPosition;
    [SerializeField] float distance, speedMovement;
    float timeInterpolate = 0.05f;
    [SerializeField] float distanceBetweenPositions;
    [SerializeField] bool isNext = true;

    // Start is called before the first frame update
    private void Awake()
    {
        initialPosition = transform.position;
    }

    void Start()
    {
        nextPosition = new Vector3(initialPosition.x, initialPosition.y , initialPosition.z+ distance);

    }

    // Update is called once per frame
    void Update()
    {

        distanceBetweenPositions = Vector3.Distance(transform.position, currentPosition);

        transform.position = Vector3.Lerp(transform.position, currentPosition, timeInterpolate * speedMovement);

        if (distanceBetweenPositions < 1f)
        {
            isNext = !isNext;
        }


        if (isNext) currentPosition = nextPosition;
        else currentPosition = initialPosition;


    }
}
