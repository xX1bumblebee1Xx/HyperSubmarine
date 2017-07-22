using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySub : MonoBehaviour
{
    public Sprite s1;
    public Sprite s2;
    int SpriteNum = 1;
    SpriteRenderer sr;
    public float Speed;
    public float RotateSpeed;
    public float PropellerSpeed;
    public GameObject Torpedo;
    public Transform FiringPoint;
    public float FireDelay;
    Rigidbody2D r;
    public int StartingHealth;
    int Health;

    void Start()
    {
        Health = StartingHealth;
        sr = GetComponentInChildren<SpriteRenderer>();
        r = GetComponent<Rigidbody2D>();
        InvokeRepeating("SwapSprite", PropellerSpeed, PropellerSpeed);
        InvokeRepeating("Fire", FireDelay, FireDelay);
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.CompareTag("Player"))
        {
            Health -= 1;
            if (Health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    void FixedUpdate()
    {
        Vector2 direction = ((Vector2)PlayerSub.instance.transform.position - (Vector2)transform.position).normalized;
        transform.up = Vector3.Lerp(transform.up, direction, RotateSpeed);
        r.AddRelativeForce(new Vector3(1, 1, 0) * Speed);
    }

    void Fire()
    {
        Instantiate(Torpedo, FiringPoint.position, transform.rotation);
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
