using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpedoScript : MonoBehaviour
{
    public float Acceleration;
    Rigidbody2D r;
	void Start ()
    {
        this.Invoke("Die", 2);
        r = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
        r.AddRelativeForce(new Vector2(0, Acceleration));	
	}

    void Die()
    {
        Destroy(gameObject);
    }
}
