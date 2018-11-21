using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleTimer : MonoBehaviour {

    [SerializeField]
    GameObject gObject;
    public float duration;
    float effectTimer;
	
	// Update is called once per frame
	void Update () {
        effectTimer += Time.deltaTime;
        if(effectTimer % 60 < duration)
        {
            if (gObject.active)
            {
                gObject.SetActive(false);
                effectTimer = 0;
            }
            else
            {
                gObject.SetActive(true);
                effectTimer = 0;
            }
        }
	}
}
