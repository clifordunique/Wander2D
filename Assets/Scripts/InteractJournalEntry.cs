using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractJournalEntry : MonoBehaviour {
    public GameObject journal;
    public int entryNumber;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Interact()
	{
		gameObject.SetActive(false);
        journal.GetComponent<JournalScript>().addJournal(entryNumber);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.gameObject.tag == "journalTrigger")
        {
            journal.GetComponent<JournalScript>().addJournal(entryNumber);
            Debug.Log("ASDASDASDASDAS");
        }
    }
    

}
