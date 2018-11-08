using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public Rigidbody rb;
    public float bulletForce = 16f;

	void Start ()
    {
		
	}

	void Update ()
    {
        rb.AddForce(transform.forward * bulletForce);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<TankManager>().health--;
        }
        else if(other.gameObject.tag == "Turret")
        {
            other.gameObject.GetComponent<TurretHitDetection>().tankObject.GetComponent<TankManager>().health--;
        }
    }
}
