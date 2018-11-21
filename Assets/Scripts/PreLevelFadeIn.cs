using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreLevelFadeIn : MonoBehaviour {

	public float fadeRate;
	SpriteRenderer sRenderer;

	// Use this for initialization
	void Start () {
		sRenderer = GetComponent<SpriteRenderer>();
		Color tempColor = sRenderer.color;

		float width = sRenderer.sprite.bounds.size.x;
		float height = sRenderer.sprite.bounds.size.y;
		float worldScreenHeight = Camera.main.orthographicSize * 2.0f;
		float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

		transform.localScale = new Vector2 (worldScreenWidth / width, worldScreenHeight / height);

		tempColor.a = 1;
		sRenderer.color = tempColor;
	}
	
	// Update is called once per frame
	void Update () {
		Color tempColor = sRenderer.color;
		tempColor.a -= fadeRate;
		sRenderer.color = tempColor;
	}
}
