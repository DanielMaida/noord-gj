using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MaterialType
{
    Metal = 0,
    Wood = 1,
    Clay = 2,
    Sugar = 3
}

public class MaterialScript : MonoBehaviour {
    
    public float BlinkRepetitions;
    public MaterialType MyMaterialType;

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
            MyCircleCollider.enabled = false;
            other.GetComponent<PlayerScript>().IncreaseMaterial(MyMaterialType);
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
