using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreLevelFadeIn : MonoBehaviour {

	public float fadeRate;
	SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
		Color tempColor = spriteRenderer.color;
		tempColor.a = 1;
		spriteRenderer.color = tempColor;
	}
	
	// Update is called once per frame
	void Update () {
		Color tempColor = spriteRenderer.color;
		tempColor.a -= fadeRate;
		spriteRenderer.color = tempColor;
	}
}
