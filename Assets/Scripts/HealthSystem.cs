using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour {

    public static HealthSystem instance;
	public Slider slider;
	public float damage;
    public float damageDelay;

    //public Text alerts;
    //public Text healthText;

	void Start () {
        instance = this;
		slider.value = 100;

        //alerts = GameObject.FindWithTag("MiddleAlerts").GetComponent<Text>();
        //healthText = GameObject.Find("HealthText").GetComponent<Text>();

        StartCoroutine (damageSubmarine());
	}

    public IEnumerator damageSubmarine() {
		while (true) {
            if (Manager.finished)
                break;
			slider.value -= damage;
            //healthText.text = slider.value.ToString();

			yield return new WaitForSeconds(damageDelay);
		}
	}

	
	void Update () {		
		if (slider.value <= 0) {
            //alerts.color = Color.red;
            //alerts.text = "You died!";
            Manager.finished = true;
        } else if (Manager.collectedParts >= Manager.partsNeeded) {
            //alerts.color = Color.green;
            //alerts.text = "You win!";

            Manager.finished = true;
        }
    }
}
