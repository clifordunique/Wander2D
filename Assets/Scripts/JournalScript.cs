using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalScript : MonoBehaviour {

    int[] entries = { 0, 0, 0, 0 };
    public int currPage = -1;
    public int pages = 0;
    public GameObject leftPage;
    public GameObject rightPage;
    public GameObject front;
    public GameObject open;
    public GameObject back;
    public Sprite[] entriesSprites;
    public Sprite leftSprite;
    public Sprite rightSprite;
	// Use this for initialization
	void Start () {
		
	}
	

    public void addJournal(int entry)
    { 
        entries[entry] = 1;
        if (entry > pages)
            pages = entry;
    }

    public void updateJournalView()
    {
        int left = (currPage * 2 + 1);
        int right = (currPage * 2 + 2);
        if (currPage >= 0)
        {
            Debug.Log(currPage);
            Debug.Log(left);

            Debug.Log(right);
            if (left >= 0)
                if (entries[left] == 1)
                    leftPage.GetComponent<Image>().sprite = entriesSprites[left - 1];
                else if (entries[left] == 0)
                   leftPage.GetComponent<Image>().sprite = leftSprite;

            if (right <= entries.Length)
                if (entries[right] == 1)
                    rightPage.GetComponent<Image>().sprite = entriesSprites[right - 1];
                else if (entries[right] == 0)
                    rightPage.GetComponent<Image>().sprite = rightSprite;
        }   
    }
    public void togglePause(Boolean a)
    {
        if (a)
            Time.timeScale = 0;
        else 
            Time.timeScale = 1;
    }

    public void turnPageLeft()
    {
        currPage--;
        Debug.Log("turnLeft");
        if (currPage >= 0) {
            updateJournalView();
            front.SetActive(false);
            open.SetActive(true);
        }
        else
        {

            Debug.Log("Cover Front");
            front.SetActive(true);
            back.SetActive(false);
            open.SetActive(false);
        }
    }
    public void turnPageRight()
    {
        currPage++;
        Debug.Log("turnRight");
        if (currPage <= pages/2 + 1)
        {
            Debug.Log("Show Open");
            updateJournalView();
            back.SetActive(false);
            front.SetActive(false);
            open.SetActive(true);
        }
        else
        {
            Debug.Log("Cover Back");
            back.SetActive(true);
            open.SetActive(false);
        }
    }
}
