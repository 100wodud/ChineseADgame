using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movePower = 10f;

    Vector3 movement;

    // Start is called before the first frame update
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            moveVelocity = Vector3.left;
        }

        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            moveVelocity = Vector3.right;
        }
        if(transform.position.x > 4.2)
        {
            transform.position = new Vector3(4.2f, transform.position.y, transform.position.z);
        } else if (transform.position.x < -4.2)
        {
            transform.position = new Vector3(-4.2f, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position += moveVelocity * movePower * Time.deltaTime;
        }
    }
}
