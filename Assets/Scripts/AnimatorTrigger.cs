using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorTrigger : MonoBehaviour {

    [SerializeField]
    Animator animator;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            animator.SetTrigger("Play");
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(6, 0, 3, .5f);
        Gizmos.DrawCube(GetComponent<BoxCollider2D>().bounds.center, new Vector2(GetComponent<BoxCollider2D>().transform.localScale.x, GetComponent<BoxCollider2D>().transform.localScale.y));
    }
}
