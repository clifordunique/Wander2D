using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

	public float respawnHeight;

	// Update is called once per frame
	public float getRespawnHeight () {
		return respawnHeight;
	}

	void OnDrawGizmos() {
		Gizmos.color = new Color (0, 1, 0, .5f);
		Gizmos.DrawCube (GetComponent<BoxCollider2D>().bounds.center, new Vector2(GetComponent<BoxCollider2D>().transform.localScale.x, GetComponent<BoxCollider2D>().transform.localScale.y));
	}
}
