﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;

public class CharacterSelectionController : MonoBehaviour {

    StartController startController;
    //public Texture[] checkmarks = new Texture[3];
    public Texture[] charSelectScreen = new Texture[16];

    bool p1ready;
    bool p2ready;
    bool p3ready;
    bool p4ready;

    bool[] playerReadyCheck = new bool[4];

    GameObject[] checks = new GameObject[4];

    int numPlayers = 2;

	// Use this for initialization
	void Start () {
        startController = GameObject.Find("StartController").GetComponent<StartController>();
        /*startController.player1 = "";
        startController.player2 = "";
        startController.player3 = "";
        startController.player4 = "";*/


        for (int i = 0; i < 4; i++)
        {
            playerReadyCheck[i] = false;
        }
        p1ready = false;
        p2ready = false;
        p3ready = false;
        p4ready = false;
    }
	
	// Update is called once per frame
    void Update()
    {
        if (startController.players.Count >= numPlayers)
        {
            for (int i = 0; i < numPlayers; i++)
            {
                CheckPlayerLockIn(startController.players, i);
            }
        }

        //CheckPlayerLockIn(ref startController.player1, startController.PLAYER1_INDEX);
        //CheckPlayerLockIn(ref startController.player2, startController.PLAYER2_INDEX);
        //CheckPlayerLockIn(ref startController.player3, startController.PLAYER3_INDEX);
        //CheckPlayerLockIn(ref startController.player4, startController.PLAYER4_INDEX);

        CheckAllPlayersReadyToStartGame();
    }

    // Make sure the player has chosen a class to play
    void CheckPlayerLockIn(List<string> players, int index)
    {
        // Press A to select Warrior
        if (/*Input.GetButtonDown("0") || */Input.GetButtonDown("A" + (index + 1)))
        {
            if (players[index] == "")
            {
                players[index] = "Warrior";
            }
            else
            {
                players[index] = "";
            }
            //Debug.Log(players[index]);
        }
        // Press B to select Ranger
        else if (/*Input.GetButtonDown("1") ||*/ Input.GetButtonDown("B" + (index + 1)))
        {
            if (players[index] == "")
            {
                players[index] = "Ranger";
            }
            else
            {
                players[index] = "";
            }
            //Debug.Log(players[index]);
        }
        // Press X to select Mage
        else if (/*Input.GetButtonDown("2") ||*/ Input.GetButtonDown("X" + (index + 1)))
        {
            if (players[index] == "")
            {
                players[index] = "Mage";
            }
            else
            {
                players[index] = "";
            }
            //Debug.Log(players[index]);
        }
        // Press Y to select Rogue
        else if (/*Input.GetButtonDown("3") ||*/ Input.GetButtonDown("Y" + (index + 1)))
        {
            if (players[index] == "")
            {
                players[index] = "Rogue";
            }
            else
            {
                players[index] = "";
            }
            //Debug.Log(players[index]);
        }
        //Debug.Log(playerIndex + "player:" + player);
    }

    // When someone presses start, make sure all players have chosen a class to play
    void CheckAllPlayersReadyToStartGame()
    {

        if (Input.GetButtonDown("Start1") || Input.GetButtonDown("Start2") || Input.GetKeyDown("7"))
        {

            bool allPlayersReady = true;

            for (int i = 0; i < numPlayers; i++)
            {
                if (startController.players[i] == "")
                {
                    allPlayersReady = false;
                }
            }

            if (allPlayersReady)
            {
                SceneManager.LoadScene(2);
            }
            else
            {
                Debug.Log("All players not ready yet");
            }
        }
    }

    void OnGUI()
    {
        string playersReadyBinary = "";
        for (int i = 0; i < 4; i++)
        {
            // Checks to see if the players have selected a char to play. Loops through the playersReadyCheck and 
            // creates a string that represents a binary number. If player is ready (character selected) 
            // then concat "1" to binary string, "0" otherwise.
            playerReadyCheck[i] = (startController.players[i] != "");
            playersReadyBinary += playerReadyCheck[i] ? "1" : "0";
        }

        // Converts the binary number to an integer, and chooses the screen based on the integer ()
        int screen = Convert.ToInt32(playersReadyBinary, 2);

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            DrawCharSelectScreen(charSelectScreen[screen]);
            
            /*int screenEdgeLength = (Screen.width > Screen.height) ? Screen.height : Screen.width;
            bool heightLimited = (Screen.width > Screen.height) ? true : false;

            if (heightLimited)
            {
                if (player1selected)
                {
                    GUI.DrawTexture(new Rect((Screen.width - Screen.height) / 2, 0, Screen.width / 10, Screen.height / 10), checkmark, ScaleMode.ScaleToFit);
                }
            }
            else
            {
                if (player1selected)
                {
                    GUI.DrawTexture(new Rect(0, (Screen.height - Screen.width) / 2, Screen.width / 10, Screen.height / 10), checkmark, ScaleMode.ScaleToFit);
                }
            }*/
        }
    }

    void DrawCharSelectScreen(Texture screen)
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), screen, ScaleMode.ScaleToFit);
    }

}
