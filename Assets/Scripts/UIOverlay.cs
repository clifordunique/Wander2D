using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOverlay : MonoBehaviour {

	public float alphaValue;
	SpriteRenderer sRenderer;

	// Use this for initialization
	void Start () {
		sRenderer = GetComponent<SpriteRenderer>();		
	}
	
	// Update is called once per frame
	void Update () {
		ScaleToScreen();

		Color tempColor = sRenderer.color;
		tempColor.a = alphaValue;
		sRenderer.color = tempColor;
	}

	void ScaleToScreen() {
		float width = sRenderer.sprite.bounds.size.x;
		float height = sRenderer.sprite.bounds.size.y;
		float worldScreenHeight = Camera.main.orthographicSize * 2.0f;
		float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

		transform.localScale = new Vector2 (worldScreenWidth / width, worldScreenHeight / height);
	}
}
