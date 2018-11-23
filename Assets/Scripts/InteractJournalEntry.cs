using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractJournalEntry : MonoBehaviour {

	public GameObject Journal;
	public int entryNo;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Interact()
	{
		gameObject.SetActive(false);
		Journal.GetComponent<JournalScript>().addJournal(entryNo);
	}
}
