﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author: Vincent McClintock
//Date: 10-18-2017

public class DestroyByContact : MonoBehaviour
{
    private GameController gameController;

    private void Start()
    {
        //this block gets the game controller object and allows it to be used within this script
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //ignores interactions with the boundary collider
        if (other.tag == "Boundary")
        {
            return;
        }

		if (other.tag == "Log") 
		{
			return;
		}

        //detects when the player is destroyed and ends the game
        if (other.tag == "Player")
        {
            gameController.GameOver();
        }


        //Destroys anything that enters the trigger
        Destroy(other.gameObject);

    }
}