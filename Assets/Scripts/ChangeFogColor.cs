using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UB;

public class ChangeFogColor : MonoBehaviour {

	[SerializeField]
	Camera camera;
	D2FogsPE fogsPE;

	public Color newColor;

	// Use this for initialization
	void Start () {
		fogsPE = camera.GetComponent<D2FogsPE>();
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player")
			fogsPE.ChangeColor(newColor);
	}

	void OnDrawGizmos() {
		Gizmos.color = new Color (0, 0, 0, .5f);
		Gizmos.DrawCube (GetComponent<BoxCollider2D>().bounds.center, new Vector2(GetComponent<BoxCollider2D>().transform.localScale.x, GetComponent<BoxCollider2D>().transform.localScale.y));
	}
}
