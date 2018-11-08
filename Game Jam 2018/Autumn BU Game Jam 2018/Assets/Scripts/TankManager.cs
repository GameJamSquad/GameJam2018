using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankManager : MonoBehaviour
{
    public string horizontal = "Horizontal_P1";
    public string vertical = "Vertical_P1";
    public string fireGun = "Fire1_P1";
    public string turretRotation = "TurretRotation_P1";

    public int playerNumber;

    public int health = 5;

    public Rigidbody rb, turretRb;
    public float movementForce;

    public Transform turretPos;
    bool canShot = true;
    public Transform firePoint;
    public GameObject bullet;
    public float gunCooldown = 1f;

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

    IEnumerator FireGun()
    {
        if(canShot == true)
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation);
            canShot = false;
            StartCoroutine(FireGun());
        }
        else
        {
            yield return new WaitForSeconds(gunCooldown);
            canShot = true;
        }
    }

    void UpdateTurretPosition()
    {
        turretRb.transform.position = turretPos.position;
    }

    void InputManager()
    {
        UpdateTurretPosition();

        if (Input.GetAxis(vertical) > 0.1f)
        {
            rb.AddForce(transform.forward * movementForce);
        }
        if (Input.GetAxis(vertical) < -0.1f)
        {
            rb.AddForce(-transform.forward * (movementForce / 2f));
        }
        if (Input.GetAxis(horizontal) < -0.1f)
        {
            Vector3 m_EulerAngleVelocity = new Vector3(0, -50, 0);
            Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
        if (Input.GetAxis(horizontal) > 0.1f)
        {
            Vector3 m_EulerAngleVelocity = new Vector3(0, 50, 0);
            Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }

        if (Input.GetAxis(turretRotation) > 0.1f)
        {
            Vector3 m_EulerAngleVelocity = new Vector3(0, 50, 0);
            Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
            turretRb.MoveRotation(turretRb.rotation * deltaRotation);
        }
        if (Input.GetAxis(turretRotation) < -0.1f)
        {
            Vector3 m_EulerAngleVelocity = new Vector3(0, -50, 0);
            Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
            turretRb.MoveRotation(turretRb.rotation * deltaRotation);
        }

        if (Input.GetButtonDown(fireGun))
        {
            Debug.Log("FIRE PLAYER " + playerNumber);
            StartCoroutine(FireGun());
        }
    }
}
