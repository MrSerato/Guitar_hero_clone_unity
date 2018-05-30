using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformanceMeter : MonoBehaviour {

	float rm;
	GameObject needle;

	// Use this for initialization
	void Start () {
		needle = transform.Find("needle").gameObject;

        Debug.Log(transform.Find("needle").localPosition);
	}
	
	// Update is called once per frame
	void Update () {
		rm = PlayerPrefs.GetInt("PerformanceMeter");
        needle.transform.localPosition = new Vector3(rm/25 + 3, 0, 0);
        if(needle.transform.localPosition.x < 2.16)
        {
            needle.transform.localPosition = new Vector3(2.16f, 0, 0);
        }
        Debug.Log(needle.transform.localPosition.x);
	}
}
