using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSub : MonoBehaviour
{
    public float Speed;
    public float RotateSpeed;
    public GameObject Torpedo;
    public Transform FiringPoint;
    Rigidbody2D r;
	void Start()
    {
        r = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate()
    {
        Vector2 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mouseScreenPosition - (Vector2)transform.position).normalized;
        transform.up = Vector3.Lerp(transform.up, direction, RotateSpeed);
        Vector2 v = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        r.AddForce(v.normalized * Speed);
	}

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(Torpedo, FiringPoint.position, transform.rotation);
        }
    }
}
