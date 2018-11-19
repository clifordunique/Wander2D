using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectsToggle : MonoBehaviour {

	public float rateOfFade;

	public static int nGameObjectsToDisable;
	public static int nGameObjectsToEnable;
	public static int nSpritesToDisable;
	public static int nSpritesToEnable;

	public GameObject[] gameObjectsToDisable = new GameObject[nGameObjectsToDisable];
	public GameObject[] gameObjectsToEnable = new GameObject[nGameObjectsToEnable];
	public GameObject[] spritesToDisable = new GameObject[nSpritesToDisable];
	public GameObject[] spritesToEnable = new GameObject[nSpritesToEnable];

	public bool disableSprites = false;

	void Update() {
		Color tmpColor;
		if (disableSprites) {
			for(int i = 0; i < spritesToDisable.Length; i++) {
				tmpColor = spritesToDisable[i].GetComponent<SpriteRenderer>().color;
				tmpColor.a -= rateOfFade;
				spritesToDisable[i].GetComponent<SpriteRenderer>().color = tmpColor;

				if(tmpColor.a <= 0)
					spritesToDisable[i].SetActive(false);
			}
		}
	}

	public void Interact()
	{
		gameObject.tag = "Untagged";
		disableGameObjects();
		enableGameObjects();

		if(spritesToDisable.Length > 0)
			disableSprites = true;
	}

	void disableGameObjects() {
		for(int i = 0; i < gameObjectsToDisable.Length; i++) {
			gameObjectsToDisable[i].SetActive(false);
		}
	}

	void enableGameObjects() {
		for(int i = 0; i < gameObjectsToEnable.Length; i++) {
			gameObjectsToEnable[i].SetActive(true);
		}
	}

	void OnDrawGizmos() {
		Gizmos.color = new Color (170, 110, 0, .5f);
		Gizmos.DrawCube (GetComponent<BoxCollider2D>().bounds.center, new Vector2(GetComponent<BoxCollider2D>().transform.localScale.x, GetComponent<BoxCollider2D>().transform.localScale.y));
	}
}
