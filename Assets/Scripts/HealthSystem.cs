using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour {

	public Slider slider;
	public int damage;
    public int damageDelay;

    public Text alerts;
    public Text healthText;

	void Start () {
		slider.wholeNumbers = true;
		slider.value = 100;

        alerts = GameObject.FindWithTag("MiddleAlerts").GetComponent<Text>();
        healthText = GameObject.Find("HealthText").GetComponent<Text>();

        StartCoroutine (damageSubmarine());
	}

    public IEnumerator damageSubmarine() {
		while (true) {
			slider.value -= damage;
            healthText.text = slider.value.ToString();

			yield return new WaitForSeconds(damageDelay);
		}
	}

	
	void Update () {		
		if (slider.value <= 0) {
            alerts.color = Color.red;
            alerts.text = "You died!";
        }
	}
}
