using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSub : MonoBehaviour
{
    public static PlayerSub instance;
    public Sprite s1;
    public Sprite s2;
    int SpriteNum = 1;
    SpriteRenderer sr;
    public float Speed;
    public float RotateSpeed;
    public float PropellerSpeed;
    public GameObject Torpedo;
    public Transform FiringPoint;
    public float TorpDamage = 20;
    Rigidbody2D r;
	void Start()
    {
        instance = this;
        sr = GetComponentInChildren<SpriteRenderer>();
        r = GetComponent<Rigidbody2D>();
        InvokeRepeating("SwapSprite", PropellerSpeed, PropellerSpeed);
	}

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.CompareTag("Enemy"))
        {
            HealthSystem.instance.slider.value -= TorpDamage;
        }
    }

    void FixedUpdate()
    {
        Vector2 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mouseScreenPosition - (Vector2)transform.position).normalized;
        transform.up = Vector3.Lerp(transform.up, direction, RotateSpeed);
        Vector2 v = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        r.AddRelativeForce(v.normalized * Speed);
	}

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(Torpedo, FiringPoint.position, transform.rotation);
        }
    }

    void SwapSprite()
    {
        if (SpriteNum == 1)
        {
            sr.sprite = s2;
            SpriteNum = 2;
        }
        else
        {
            sr.sprite = s1;
            SpriteNum = 1;
        }
    }
}
