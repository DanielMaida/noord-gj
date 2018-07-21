using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialScript : MonoBehaviour {
    
    public float BlinkRepetitions;

    private CircleCollider2D MyCircleCollider;
    private SpriteRenderer MySpriteRenderer;

	// Use this for initialization
	void Start () {
        MyCircleCollider = GetComponent<CircleCollider2D>();
        MySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(PickupCoroutine());
        }
    }

    IEnumerator PickupCoroutine()
    {
        for(int i = 0; i < BlinkRepetitions; i++)
        {
            MySpriteRenderer.color = Color.red;
            yield return new WaitForSeconds(0.5f);
            MySpriteRenderer.color = Color.white;
            yield return new WaitForSeconds(0.5f);
        }
        Destroy(gameObject);
    }
    
}
