using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractJournalEntry : MonoBehaviour {


	public AudioSource paperfx;

	// Use this for initialization
	void Start () {
		paperfx = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Interact()
	{
		gameObject.SetActive(false);
		paperfx.Play();
	}
}
