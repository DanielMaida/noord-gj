using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScript : MonoBehaviour {

    [Header("Movement components")]
    public float ThrustAxis;
    public float RotationAxis;
    public float Angle;

    [Header("Player Physics")]
    public float Speed;

    [Header("Player Inventory")]
    private Stack<MaterialType> PlayerInventory;
    public GameObject[] ShotMaterialsPrefabs;

    private Rigidbody2D MyRigidbody2D;
    private SpriteRenderer MySpriteRenderer;

	// Use this for initialization
	void Start () {
        MyRigidbody2D = GetComponent<Rigidbody2D>();
        MySpriteRenderer = GetComponent<SpriteRenderer>();
        PlayerInventory = new Stack<MaterialType>(3);
	}
	
	// Update is called once per frame
	void Update () {
        CheckMovement();
        ShootMaterial();
    }

    private void FixedUpdate()
    {
        MyRigidbody2D.velocity = transform.up * Speed * ThrustAxis;

        if (RotationAxis != 0)
        {
            MyRigidbody2D.MoveRotation(MyRigidbody2D.rotation + RotationAxis);
        }
    }

    private void CheckMovement()
    {
        RotationAxis = Input.GetAxisRaw("Horizontal");
        ThrustAxis = Input.GetAxisRaw("Vertical");
    }
    
    private void ShootMaterial()
    {
        if(Input.GetButtonDown("Fire1") && PlayerInventory.Count > 0)
        {
            //Check the rotation if you want to instantiated a rotated object
            GameObject shootMaterial = Instantiate(ShotMaterialsPrefabs[(int)PlayerInventory.Pop()], transform.position, Quaternion.identity);
            shootMaterial.GetComponent<ShotMaterialScript>().ShootDirection = transform.up;
        }
    }
    
    public void IncreaseMaterial(MaterialType material)
    {
        PlayerInventory.Push(material);
    }

    public void DecreaseMaterials()
    {
        PlayerInventory.Pop();
    }

    IEnumerator BlinkCoroutine()
    {
        while(PlayerInventory.Count > 0)
        {
            MySpriteRenderer.color = Color.yellow;
            yield return new WaitForSeconds(.5f);
            MySpriteRenderer.color = Color.white;
            yield return new WaitForSeconds(.5f);
        }
    }

}
