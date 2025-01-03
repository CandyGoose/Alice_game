﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomp : MonoBehaviour {

    public GameObject RedCoin;
    private Rigidbody2D playerRigidBody;
    public float bounceForce;
    // Use this for initialization
    void Start () {
        playerRigidBody = transform.parent.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {

            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
            Instantiate(RedCoin, other.transform.position, other.transform.rotation);
            playerRigidBody.linearVelocity = new Vector3(playerRigidBody.linearVelocity.x, bounceForce, 0f);

        }

    }
}
