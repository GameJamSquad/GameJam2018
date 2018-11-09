using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGamePaused = false;
    bool isGameOver = false;
    public bool lobbyOpen = true;

    public GameObject lobbyObject;
    public Text winText;
    int winningPlayer;

    bool hasFirstPlayer = false, hasSecondPlayer = false, hasThirdPlayer = false, hasFourthPlayer = false;
    public int firstPlayerTank, secondPlayerTank, thirdPlayerTank, fourthPlayerTank;

    public List<GameObject> playerPanels;
    public List<GameObject> playerInPanels;

    public int numOfPlayers = 1;
    public List<TankManager> tanks;

    public List<TankTurret> turrets;

    public List<GameObject> tankTypes;

    public int scoreToWin = 10;

    public float respawnTimer = 5f;
    public List<Transform> respawnPoints;

    public float timeSpeed = 1;
    public bool slowdownOn, speedupOn;

    private void Start()
    {
        
    }

    public void AdjustTimeSpeed(float amount)
    {
        timeSpeed += amount;
        Time.timeScale = timeSpeed;
        StartCoroutine(ResetTimeSpeedCooldown());
    }

    IEnumerator ResetTimeSpeedCooldown()
    {
        yield return new WaitForSeconds(5f * timeSpeed);
        timeSpeed = 1;
        slowdownOn = false;
        speedupOn = false;
        Time.timeScale = timeSpeed;
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
        if (isGameOver)
        {
            if (Input.GetButtonDown("Fire1_P1") || Input.GetButtonDown("Fire1_P2") || Input.GetButtonDown("Fire1_P3") || Input.GetButtonDown("Fire1_P4"))
            {
                SceneManager.LoadScene(Application.loadedLevel);
            }
        }

        Debug.Log(timeSpeed);
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
                winningPlayer = i + 1;
                EndGame();
            }
        }
    }

    void EndGame()
    {
        winText.text = "Player " + winningPlayer + " wins the game! \nPress A to start again!";
        winText.gameObject.SetActive(true);
        isGameOver = true;
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

