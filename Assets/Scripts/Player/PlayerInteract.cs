using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {

	[HideInInspector]
	public GameObject currentObject = null;
	public GameObject prompt;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Interact") && currentObject) {
			currentObject.SendMessage("Interact");
			prompt.SetActive(false);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("InteractObject")) {
			currentObject = other.gameObject;
			prompt.SetActive(true);
		}		
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.CompareTag("InteractObject") && other.gameObject == currentObject) {
			currentObject = null;
			prompt.SetActive(false);
		}
	}
}
