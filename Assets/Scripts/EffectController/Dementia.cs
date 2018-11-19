using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dementia : EffectController {

	public static int itemsListSize;
	public SpriteRenderer[] itemsList;
	static GameObject currItem;
	bool isDone = true;
	float effectTimer = 0;
	SpriteRenderer currSprite;
	Color tmpColor;

	void Start() {
		itemsList = GetComponentsInChildren<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		// print("effectTimer % 60 = " + effectTimer % 60);
		if(isActive) {
			effectTimer += Time.deltaTime;
			if(effectTimer % 60 < 5) {
				isDone = false;
			} else if(effectTimer % 60 >= 5 && effectTimer % 60 < 20){
				isDone = true;
			} else if(effectTimer % 60 >= 20) {
				effectTimer = 0;
			}
		}

		if(!isDone && isActive) {
			for(int i = 0; i < itemsList.Length; i++) {
				currSprite = itemsList[i];
				tmpColor = currSprite.color;
				if(tmpColor.a > 0.05)
					tmpColor.a -= 0.003f;
				currSprite.color = tmpColor;
			}
		}
		
		if(isDone){
			for(int i = 0; i < itemsList.Length; i++) {
				currSprite = itemsList[i];
				tmpColor = currSprite.color;
				if(tmpColor.a < 0.15)
					tmpColor.a += 0.005f;
				currSprite.color = tmpColor;
			}
		}

		if(!isActive){
			for(int i = 0; i < itemsList.Length; i++) {
				currSprite = itemsList[i];
				tmpColor = currSprite.color;
				if(tmpColor.a < 1)
					tmpColor.a += 0.005f;
				currSprite.color = tmpColor;
			}
		}
	}
}
