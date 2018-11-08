using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankManager : MonoBehaviour
{

    public Rigidbody rb;

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
            Vector3 newPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.1f);
            transform.localPosition = newPos;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Quaternion newRot = new Quaternion(transform.rotation.x, transform.rotation.y + 0.1f, transform.rotation.z, 0);
            rb.rotation = newRot;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Quaternion newRot = new Quaternion(transform.rotation.x, transform.rotation.y - 0.1f, transform.rotation.z, 0);
            rb.rotation = newRot;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Quaternion newRot = new Quaternion(transform.rotation.x, transform.rotation.y + 0.1f, transform.rotation.z, 0);
            transform.rotation = newRot;
        }
    }
}
