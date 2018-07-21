using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    [Header("Movement components")]
    public float ThrustAxis;
    public float RotationAxis;
    public float Angle;

    [Header("Player Parameters")]
    public float Speed;

    private Rigidbody2D MyRigidbody2D;

	// Use this for initialization
	void Start () {
        MyRigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        CheckMovement();
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

}
