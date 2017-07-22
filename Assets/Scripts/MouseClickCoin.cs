using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseClickCoin : MonoBehaviour {

    public Slider slider;
    public Text healthText;
    public Text partsText;

    public GameObject coin;
    public int maxAmount;
    public bool randomAmount;

    public void Start() {
        slider = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<Slider>();
        healthText = GameObject.Find("HealthText").GetComponent<Text>();
        partsText = GameObject.FindGameObjectWithTag("PartsCounter").GetComponent<Text>();
    }

    public void OnMouseDown() {
        if (Manager.finished)
            return;

        if (randomAmount) {
            slider.value += Random.Range(0, maxAmount);
        } else {
            slider.value += maxAmount;
        }
        healthText.text = slider.value.ToString();
        Manager.collectedParts++;
        partsText.text = "Ship Parts Collected: " + Manager.collectedParts;
        Destroy(coin);
    }
}
