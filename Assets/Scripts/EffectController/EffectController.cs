using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour {

	public bool isActive = false;

	public void setIsActive(bool isActive){
		this.isActive = isActive;
	}

	public bool getIsActive() {
		return isActive;
	}
}
