using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour {

    public GameObject prefab;
    public int delay;
    public bool randomDelay;
    public int minDelay;
    public int maxDelay;

    public int i = 0;
	
	void Update () {
        if (Manager.finished)
            return;

        if (randomDelay)
            delay = Random.Range(minDelay, maxDelay);

        if (i >= delay) {
            Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), Camera.main.farClipPlane / 2));
            Instantiate(prefab, screenPosition, Quaternion.identity);
            i = 0;
        }
        i++;
    }
}
