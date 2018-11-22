using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxTrigger : MonoBehaviour {

    [SerializeField]
    GameObject parallax;
    public float fadeRate;
    bool active = false;
    public SpriteRenderer[] layers;

    // Use this for initialization
    void Start()
    {
        layers = new SpriteRenderer[parallax.transform.childCount];

        for (int i = 0; i < parallax.transform.childCount; i++)
            layers[i] = parallax.transform.GetChild(i).GetComponentInParent<SpriteRenderer>();
    }

    void Update()
    {
        Color tmpColor;
        if (active)
        {
            for(int i = 0; i < layers.Length; i++) {
                tmpColor = layers[i].color;
                tmpColor.a -= fadeRate;
                layers[i].color = tmpColor;
                if (tmpColor.a <= 0)
                    parallax.SetActive(false);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            print("is active now");
            active = true;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(3, 3, 3, .5f);
        Gizmos.DrawCube(GetComponent<BoxCollider2D>().bounds.center, new Vector2(GetComponent<BoxCollider2D>().transform.localScale.x, GetComponent<BoxCollider2D>().transform.localScale.y));
    }
}
