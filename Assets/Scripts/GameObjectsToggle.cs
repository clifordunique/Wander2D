using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectsToggle : MonoBehaviour {

	public static int nGameObjectsToDisable = 0;
	public static int nGameObjectsToEnable;

	GameObject test;

	public GameObject[] gameObjectsToDisable = new GameObject[nGameObjectsToDisable];
	public GameObject[] gameObjectsToEnable = new GameObject[nGameObjectsToEnable];

	public void Interact()
	{
		disableGameObjects();
	}

	void disableGameObjects() {
		for(int i = 0; i < gameObjectsToDisable.Length; i++) {
			gameObjectsToDisable[i].SetActive(false);
		}
		for(int i = 0; i < gameObjectsToEnable.Length; i++) {
			gameObjectsToEnable[i].SetActive(true);
		}
	}

	void enableGameObjects() {
		for(int i = 0; i < gameObjectsToEnable.Length; i++) {
			gameObjectsToEnable[i].SetActive(false);
		}
		for(int i = 0; i < gameObjectsToDisable.Length; i++) {
			gameObjectsToDisable[i].SetActive(true);
		}
	}

	void OnDrawGizmos() {
		Gizmos.color = new Color (170, 110, 0, .5f);
		Gizmos.DrawCube (GetComponent<BoxCollider2D>().bounds.center, new Vector2(GetComponent<BoxCollider2D>().transform.localScale.x, GetComponent<BoxCollider2D>().transform.localScale.y));
	}
}
