using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractJournalEntry : MonoBehaviour {


	public AudioSource paper;

	// Use this for initialization
	void Start () {
		paper = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Interact()
	{
		gameObject.SetActive(false);
		paper.Play();
	}
}
