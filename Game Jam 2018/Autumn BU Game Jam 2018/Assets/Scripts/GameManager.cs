﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGamePaused = false;
    public bool lobbyOpen = true;

    public GameObject lobbyObject;

    bool hasFirstPlayer = false, hasSecondPlayer = false, hasThirdPlayer = false, hasFourthPlayer = false;
    public int firstPlayerTank, secondPlayerTank, thirdPlayerTank, fourthPlayerTank;

    public List<GameObject> playerPanels;
    public List<GameObject> playerInPanels;

    public int numOfPlayers = 1;
    public List<TankManager> tanks;

    public List<TankTurret> turrets;

    public List<GameObject> tankTypes;
    //public List<GameObject> tankTurrets;

    public int scoreToWin = 10;

    public float respawnTimer = 5f;
    public List<Transform> respawnPoints;

    private void Start()
    {
        
    }

    private void Update()
    {
        lobbyObject.SetActive(lobbyOpen);

        CheckPlayerInput();
        PanelManager();

        if (lobbyOpen)
        {
            isGamePaused = true;
        }
    }

    void PanelManager()
    {
        if (hasFirstPlayer)
        {
            playerPanels[0].SetActive(false);
            playerInPanels[0].SetActive(true);
        }
        else
        {
            playerPanels[0].SetActive(true);
            playerInPanels[0].SetActive(false);
        }

        if (hasSecondPlayer)
        {
            playerPanels[1].SetActive(false);
            playerInPanels[1].SetActive(true);
        }
        else
        {
            playerPanels[1].SetActive(true);
            playerInPanels[1].SetActive(false);
        }

        if (hasThirdPlayer)
        {
            playerPanels[2].SetActive(false);
            playerInPanels[2].SetActive(true);
        }
        else
        {
            playerPanels[2].SetActive(true);
            playerInPanels[2].SetActive(false);
        }

        if (hasFourthPlayer)
        {
            playerPanels[3].SetActive(false);
            playerInPanels[3].SetActive(true);
        }
        else
        {
            playerPanels[3].SetActive(true);
            playerInPanels[3].SetActive(false);
        }
    }

    public void AddFirstPlayer()
    {
        hasFirstPlayer = true;
        playerPanels[0].SetActive(!hasFirstPlayer);
        numOfPlayers++;
    }
    public void AddSecondPlayer()
    {
        hasSecondPlayer = true;
        numOfPlayers++;
    }
    public void AddThirdPlayer()
    {
        hasThirdPlayer = true;
        numOfPlayers++;
    }
    public void AddFourthPlayer()
    {
        hasFourthPlayer = true;
        numOfPlayers++;
    }

    public void SelectPlayerOneTank(int ID)
    {
        firstPlayerTank = ID;
    }
    public void SelectPlayerTwoTank(int ID)
    {
        secondPlayerTank = ID;
    }
    public void SelectPlayerThreeTank(int ID)
    {
        thirdPlayerTank = ID;
    }
    public void SelectPlayerFourTank(int ID)
    {
        fourthPlayerTank = ID;
    }

    public void CheckScores()
    {
        for(int i = 0; i < tanks.Count; i++)
        {
            if(tanks[i].score >= scoreToWin)
            {
                EndGame();
            }
        }
    }

    void EndGame()
    {
        isGamePaused = true;
    }

    public void StartGame()
    {
        for(int i = 0; i < numOfPlayers; i++)
        {
            if (i == 0)
            {
                GameObject curTank = Instantiate(tankTypes[firstPlayerTank], respawnPoints[0].position, Quaternion.identity);
                tanks.Add(curTank.GetComponentInChildren<TankManager>());
                tanks[i].playerNumber = i + 1;
            }
            if (i == 1)
            {
                GameObject curTank = Instantiate(tankTypes[secondPlayerTank], respawnPoints[1].position, Quaternion.identity);
                tanks.Add(curTank.GetComponentInChildren<TankManager>());
                tanks[i].playerNumber = i + 1;
            }
            if (i == 2)
            {
                GameObject curTank = Instantiate(tankTypes[thirdPlayerTank], respawnPoints[2].position, Quaternion.identity);
                tanks.Add(curTank.GetComponentInChildren<TankManager>());
                tanks[i].playerNumber = i + 1;
            }
            if (i == 3)
            {
                GameObject curTank = Instantiate(tankTypes[fourthPlayerTank], respawnPoints[3].position, Quaternion.identity);
                tanks.Add(curTank.GetComponentInChildren<TankManager>());
                tanks[i].playerNumber = i + 1;
            }
        }

        lobbyOpen = false;
        isGamePaused = false;
    }
    

    void CheckPlayerInput()
    {
        if (Input.GetButtonDown("Fire1_P1"))
        {
            AddFirstPlayer();
        }
        if (Input.GetButtonDown("Fire1_P2"))
        {
            AddSecondPlayer();
        }
        if (Input.GetButtonDown("Fire1_P3"))
        {
            AddThirdPlayer();
        }
        if (Input.GetButtonDown("Fire1_P4"))
        {
            AddFourthPlayer();
        }
    }
}

[System.Serializable]
public class TankTurret
{
    public int id;
    public GameObject model;
    public float rotationSpeed;
    public float shellVelocity;
    public int damage;
}

