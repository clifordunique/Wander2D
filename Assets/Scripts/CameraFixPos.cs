using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFixPos : MonoBehaviour {

    CameraFollow cFollow;

	// Use this for initialization
	void Start () {
        cFollow = Camera.main.GetComponent<CameraFollow>();
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            cFollow.setMinX(Camera.main.transform.position.x);
            cFollow.setMaxX(Camera.main.transform.position.x);
            this.gameObject.SetActive(false);
        }
    }
}
