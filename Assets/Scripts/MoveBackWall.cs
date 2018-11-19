using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackWall : MonoBehaviour {


	void Start() {
	}

	void OnTriggerExit2D(Collider2D other) {
		if(other.gameObject.tag == "Player"){
			print("Player entered");
			gameObject.layer = 9; //Platform layer
		}
	}

	void OnDrawGizmos() {
		Gizmos.color = new Color (3, 0, 3, .5f);
		Gizmos.DrawCube (GetComponent<BoxCollider2D>().bounds.center, new Vector2(GetComponent<BoxCollider2D>().transform.localScale.x, GetComponent<BoxCollider2D>().transform.localScale.y));
	}
}
