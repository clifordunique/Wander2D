﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMentalHealth : MonoBehaviour {

	public float health = 1f;

	[SerializeField] private MentalHealth mentalHealth;
	[SerializeField] private EffectController effect;
	Vector3 resetPoint;
	bool criticalLevel = false;
	float timer = 0;

	void Start() {
		resetPoint = transform.position;
	}

	void Update() {
		// print("timer % 60 = " + timer % 60);
		if(criticalLevel) {
			timer += Time.deltaTime;
			if(timer % 60 >= 5) {
				resetLevel();
			}
		}
	}
	
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.CompareTag("FallDetector")) {
			changeHealth(-0.1f);
		}
	}

	void resetLevel() {
		changeHealth(1f);
		transform.position = resetPoint;
	}

	void changeHealth(float damageValue) {
		health += damageValue;

		if(health >= 1) {
			health = 1;
			timer = 0;
		}
		
		if(health < 0f)
			health = 0f;

		if(health < 0.25f) {
			effect.setIsActive(true);
		} else {
			effect.setIsActive(false);
		}

		if(health < 0.15f) {
			timer = 0;
			criticalLevel = true;
		}
		else {
			criticalLevel = false;
		}

		mentalHealth.SetSize(health);
	}
}
