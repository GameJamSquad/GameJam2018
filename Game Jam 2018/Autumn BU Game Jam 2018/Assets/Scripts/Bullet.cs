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
}
