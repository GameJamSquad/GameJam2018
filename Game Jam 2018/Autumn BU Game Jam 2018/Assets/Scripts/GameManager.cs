using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGamePaused = false;
    public bool lobbyOpen = true;

    public GameObject lobbyObject;

    bool hasFirstPlayer = false, hasSecondPlayer = false, hasThirdPlayer = false, hasFourthPlayer = false;

    public GameObject playerPanels;

    public int numOfPlayers = 1;
    public List<TankManager> tanks;

    public List<TankTurret> turrets;

    public GameObject tank, turret;
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
    }

    public void AddFirstPlayer()
    {
        hasFirstPlayer = true;
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

    void StartGame()
    {
        for(int i = 0; i < numOfPlayers; i++)
        {
            GameObject curTank = Instantiate(tank, transform.position, Quaternion.identity);
            tanks.Add(curTank.GetComponent<TankManager>());
            tanks[i].playerNumber = i + 1;
        }
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

