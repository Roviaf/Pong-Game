using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableCube : MonoBehaviour
{
    // Update is called once per frame
    [SerializeField] float speed = 1f;
    void Update()
    {
        MovingUpAndDown();
    }

    private void MovingUpAndDown()
    {
        if (Vector3.Distance(transform.position, new Vector3(-8, 4, 0)) < 0.2f)
        {
            MovingDown();
        }
        else if (Vector3.Distance(transform.position, new Vector3(-8, -4, 0)) < 0.2f)
        {
            MovingUp();
        }
        else
        {
            MovingUp();
            MovingDown();
        }

    }

    private void MovingUp()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = transform.position + new Vector3(0, 1, 0) * Time.deltaTime * speed;
        }
    }

    private void MovingDown()
    {
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = transform.position + new Vector3(0, -1, 0) * Time.deltaTime * speed;
        }
    }
}
