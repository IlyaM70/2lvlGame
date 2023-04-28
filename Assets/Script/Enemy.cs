using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform[] Points;
    public float Speed;

    private int index;
    private Transform currentPoint;
    


    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        currentPoint = Points[index];
    }

    // Update is called once per frame
    void Update()
    {
       

        transform.position = Vector3.MoveTowards(transform.position, currentPoint.position, Speed * Time.deltaTime);

        if (transform.position == currentPoint.position)
        {
            index++;
            if (index >= Points.Length)
            {
                index = 0;
                currentPoint = Points[index];

            }
            else
            {
                currentPoint = Points[index];
            }

        }
    }
}
