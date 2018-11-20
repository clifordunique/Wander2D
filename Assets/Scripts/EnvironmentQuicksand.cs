using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentQuicksand : MonoBehaviour {

	[SerializeField]
	Player player;
	[SerializeField]
	GameObject exclamation;
	float maxJumpHeight;
	float minJumpHeight;
	float moveSpeed;

	void Start () {
		maxJumpHeight = player.getMaxJumpHeight();
		minJumpHeight = player.getMinJumpHeight();
		moveSpeed = player.getMoveSpeed();
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Player"){
			// print("Player entered zoom");
			player.setMaxJumpHeight(0.1f);
			player.setMinJumpHeight(0.1f);
			player.setMoveSpeed(moveSpeed/2);
			exclamation.SetActive(true);
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if(other.gameObject.tag == "Player"){
			// print("Player entered zoom");
			player.setMaxJumpHeight(maxJumpHeight);
			player.setMinJumpHeight(minJumpHeight);
			player.setMoveSpeed(moveSpeed);
			exclamation.SetActive(false);
		}
	}
}
