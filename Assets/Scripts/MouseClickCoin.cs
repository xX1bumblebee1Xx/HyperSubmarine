using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseClickCoin : MonoBehaviour
{
    public int healthRestore;

    public void Start() {
    }

    public void OnCollisionEnter2D(Collision2D c) {
        if (c.gameObject.CompareTag("PlayerSub"))
        {
            HealthSystem.instance.slider.value += healthRestore;
            Destroy(gameObject);
        }
    }
}
