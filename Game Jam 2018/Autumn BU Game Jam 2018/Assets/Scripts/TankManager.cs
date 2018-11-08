using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankManager : MonoBehaviour
{
    public int playerNumber;

    public Rigidbody rb, turretRb;
    public float movementForce;

	void Start ()
    {
		
	}

	void Update ()
    {
		
	}

    void FixedUpdate()
    {
        InputManager();
    }

    void InputManager()
    {
        if (playerNumber == 1)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetAxis("Vertical_P1") > 0.1f)
            {
                rb.AddForce(transform.forward * movementForce);
            }
            if (Input.GetKey(KeyCode.S) || Input.GetAxis("Vertical_P1") < -0.1f)
            {
                rb.AddForce(-transform.forward * (movementForce / 2f));
            }
            if (Input.GetKey(KeyCode.A) || Input.GetAxis("Horizontal_P1") < -0.1f)
            {
                Vector3 m_EulerAngleVelocity = new Vector3(0, -50, 0);
                Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
                rb.MoveRotation(rb.rotation * deltaRotation);
            }
            if (Input.GetKey(KeyCode.D) || Input.GetAxis("Horizontal_P1") > 0.1f)
            {
                Vector3 m_EulerAngleVelocity = new Vector3(0, 50, 0);
                Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
                rb.MoveRotation(rb.rotation * deltaRotation);
            }

            if (Input.GetKey(KeyCode.E) || Input.GetAxis("TurretRotation_P1") > 0.1f)
            {
                Vector3 m_EulerAngleVelocity = new Vector3(0, 50, 0);
                Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
                turretRb.MoveRotation(turretRb.rotation * deltaRotation);
            }
            if (Input.GetKey(KeyCode.Q) || Input.GetAxis("TurretRotation_P1") < -0.1f)
            {
                Vector3 m_EulerAngleVelocity = new Vector3(0, -50, 0);
                Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
                turretRb.MoveRotation(turretRb.rotation * deltaRotation);
            }
            if (Input.GetKey(KeyCode.F) || Input.GetButton("Fire1_P1"))
            {
                Debug.Log("FIRE PLAYER 1");
            }
        }
        else if (playerNumber == 2)
        {
            if (Input.GetKey(KeyCode.U) || Input.GetAxis("Vertical_P2") > 0.1f)
            {
                rb.AddForce(transform.forward * movementForce);
            }
            if (Input.GetKey(KeyCode.J) || Input.GetAxis("Vertical_P2") < -0.1f)
            {
                rb.AddForce(-transform.forward * (movementForce / 2f));
            }
            if (Input.GetKey(KeyCode.H) || Input.GetAxis("Horizontal_P2") < -0.1f)
            {
                Vector3 m_EulerAngleVelocity = new Vector3(0, -50, 0);
                Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
                rb.MoveRotation(rb.rotation * deltaRotation);
            }
            if (Input.GetKey(KeyCode.K) || Input.GetAxis("Horizontal_P2") > 0.1f)
            {
                Vector3 m_EulerAngleVelocity = new Vector3(0, 50, 0);
                Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
                rb.MoveRotation(rb.rotation * deltaRotation);
            }

            if (Input.GetKey(KeyCode.I) || Input.GetAxis("TurretRotation_P2") > 0.1f)
            {
                Vector3 m_EulerAngleVelocity = new Vector3(0, 50, 0);
                Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
                turretRb.MoveRotation(turretRb.rotation * deltaRotation);
            }
            if (Input.GetKey(KeyCode.Y) || Input.GetAxis("TurretRotation_P2") < -0.1f)
            {
                Vector3 m_EulerAngleVelocity = new Vector3(0, -50, 0);
                Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
                turretRb.MoveRotation(turretRb.rotation * deltaRotation);
            }
            if (Input.GetKey(KeyCode.L) || Input.GetButton("Fire1_P2"))
            {
                Debug.Log("FIRE PLAYER 2");
            }
        }
    }
}
