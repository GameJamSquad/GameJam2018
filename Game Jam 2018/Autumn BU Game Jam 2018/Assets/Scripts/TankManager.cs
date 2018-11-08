using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankManager : MonoBehaviour
{

    public Rigidbody rb;
    public float movementForce;

	void Start ()
    {
		
	}

	void Update ()
    {
		
	}

    void FixedUpdate()
    {
        MovementManager();    
    }

    void MovementManager()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * movementForce);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-transform.forward * (movementForce / 2f));
        }
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 m_EulerAngleVelocity = new Vector3(0, -50, 0);
            Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 m_EulerAngleVelocity = new Vector3(0, 50, 0);
            Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
    }
}
