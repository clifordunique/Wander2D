using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentSkyFade : MonoBehaviour {

    public float fadeRate;

	[SerializeField]
	GameObject sky;
	SpriteRenderer skyRenderer;
    bool fadeSky;

	// Use this for initialization
	void Start () {
        skyRenderer = sky.gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        Color tmpColor;
		if(fadeSky)
        {
            tmpColor = skyRenderer.color;
            tmpColor.a -= fadeRate;
            skyRenderer.color = tmpColor;
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            fadeSky = true;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 3, 3, .5f);
        Gizmos.DrawCube(GetComponent<BoxCollider2D>().bounds.center, new Vector2(GetComponent<BoxCollider2D>().transform.localScale.x, GetComponent<BoxCollider2D>().transform.localScale.y));
    }
}
