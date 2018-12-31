﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    [SerializeField] Vector3 launchVelocity;

    private Rigidbody rigidBody;
    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        rigidBody.useGravity = false;
	}

    public void Launch(Vector3 velocity)
    {
        rigidBody.useGravity = true;
        rigidBody.velocity = velocity ;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
