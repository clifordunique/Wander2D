using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFade : MonoBehaviour {

	public float rateOfFade;
	SpriteRenderer sRenderer;

	// Use this for initialization
	void Start () {
		sRenderer = gameObject.GetComponent<SpriteRenderer>();
		Color tmpColor = sRenderer.color;
		tmpColor.a = 1;
		sRenderer.color = tmpColor;
	}
	
	// Update is called once per frame
	void Update () {
		Color tmpColor = sRenderer.color;
		tmpColor.a -= rateOfFade;
		sRenderer.color = tmpColor;
	}
}
