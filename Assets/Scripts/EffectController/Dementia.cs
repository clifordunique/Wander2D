using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dementia : EffectController {

	public static int itemsListSize;
	public SpriteRenderer[] itemsList;
	static GameObject currItem;
	bool isDone = true;
	float effectTimer = 0;

	void Start() {
		itemsList = GetComponentsInChildren<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		// print("effectTimer % 60 = " + effectTimer % 60);
		if(isActive) {
			effectTimer += Time.deltaTime;
			if(effectTimer % 60 >= 0 && effectTimer % 60 < 3) {
				isDone = false;
			} else if(effectTimer % 60 >= 3 && effectTimer % 60 < 7){
				isDone = true;
			} else if(effectTimer % 60 >= 7) {
				effectTimer = 0;
			}
		}

		if(!isDone && isActive) {
			for(int i = 0; i < itemsList.Length; i++) {
				SpriteRenderer currSprite = itemsList[i];
				Color tmpColor = currSprite.color;
				if(tmpColor.a != 0)
					tmpColor.a = tmpColor.a - 0.01f;
				currSprite.color = tmpColor;
			}
		}
		
		if(isDone || !isActive){
			for(int i = 0; i < itemsList.Length; i++) {
				SpriteRenderer currSprite = itemsList[i];
				Color tmpColor = currSprite.color;
				if(tmpColor.a != 1)
					tmpColor.a = tmpColor.a + 0.01f;
				currSprite.color = tmpColor;
			}
		}
	}
}
