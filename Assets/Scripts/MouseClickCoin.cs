using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseClickCoin : MonoBehaviour {

    public Slider slider;
    public Text healthText;

    public GameObject coin;
    public int maxAmount;
    public bool randomAmount;

    public void Start() {
        slider = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<Slider>();
        healthText = GameObject.Find("HealthText").GetComponent<Text>();
    }

    public void OnMouseDown() {
        if (randomAmount) {
            slider.value += Random.Range(0, maxAmount);
        } else {
            slider.value += maxAmount;
        }
        healthText.text = slider.value.ToString();
        Destroy(coin);
    }
}
