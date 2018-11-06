using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBackground : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		this.GetComponentInParent<Camera>().orthographicSize = Camera.main.orthographicSize;
	}
}
