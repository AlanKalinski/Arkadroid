﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTwo : MonoBehaviour {

    public float ballInitialVelocity = 600f;
    private Rigidbody rb;
    private bool ballInPlay;

    void Start () {
		
	}
	
	void Update () {
        if (Input.GetButtonDown("Fire2") && ballInPlay == false)
        {
            transform.parent = null;
            ballInPlay = true;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(ballInitialVelocity, ballInitialVelocity, 0));
        }
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider col)
    {
        print("Tag: " + col.tag);
        if (col.CompareTag("PlayerDeathSpace"))
        {
            GM.instance.pointForPlayer2();
        }
        else if (col.CompareTag("EnemyDeathSpace"))
        {
            GM.instance.pointForPlayer1();
        }
    }
}
