using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxTrigger : MonoBehaviour {

    [SerializeField]
    GameObject parallax;
    public float newY;
    bool active = false;
    Vector2 parallaxPos;
    public float duration = 1.0f;
    float elapsed = 0.0f;
    float currentYPos;

    // Use this for initialization
    void Start () {
        parallaxPos = parallax.transform.localPosition;
    }

    void Update()
    {
        if (active)
        {
            print(elapsed);
            elapsed += (Time.deltaTime / duration);
            parallaxPos.y = Mathf.Lerp(currentYPos, newY, elapsed);
            parallax.transform.localPosition = parallaxPos;
            if (elapsed > 1.0f)
            {
                active = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            elapsed = 0.0f;
            active = true;
            currentYPos = parallaxPos.y;
            print("dis bitch here " + currentYPos);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(3, 3, 3, .5f);
        Gizmos.DrawCube(GetComponent<BoxCollider2D>().bounds.center, new Vector2(GetComponent<BoxCollider2D>().transform.localScale.x, GetComponent<BoxCollider2D>().transform.localScale.y));
    }
}
