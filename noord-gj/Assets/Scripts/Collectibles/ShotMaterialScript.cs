using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMaterialScript : MonoBehaviour {

    public MaterialType MyMaterialType;
    public Vector2 ShootDirection;

    private Rigidbody2D MyRigidBody2D;
    
	// Use this for initialization
	void Start () {
        MyRigidBody2D = GetComponent<Rigidbody2D>();
        MyRigidBody2D.AddForce(ShootDirection * 3, ForceMode2D.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
