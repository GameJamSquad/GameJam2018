using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int numOfPlayers = 1;
    public List<TankManager> tanks;

    public GameObject tank;

    private void Start()
    {
        
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
}
