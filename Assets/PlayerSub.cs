using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSub : MonoBehaviour
{
    public float Speed;
    public float RotateSpeed;
    Rigidbody2D r;
	void Start()
    {
        r = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate()
    {
        Vector3 m = Input.mousePosition;
        //Quaternion targetRotation = Quaternion.LookRotation(m - transform.position);
        //transform.rotation = transform.rotation * Quaternion.Inverse(targetRotation);
        //Debug.Log(AngleBetweenVector2(transform.position, m));
        //float targetAngle = (Mathf.Atan2(m.y, m.x) * Mathf.Rad2Deg) - 90f;
        //if (transform.eulerAngles.z < targetAngle)
        //{
        //    r.AddTorque(RotateSpeed);
        //}
        //else
        //{
        //    r.AddTorque(-RotateSpeed);
        //}
        Vector2 v = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        r.AddRelativeForce(v.normalized * Speed);
	}
}
