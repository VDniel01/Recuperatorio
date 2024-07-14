using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameOver = false;
    public static bool winCondition = false;
    public static int actualPlayer = 0;

    public List<Controller_Target> targets;
    public List<Controller_Player> players;

    public void Start()
    {
        Physics.gravity = new Vector3(0, -30, 0);
        gameOver = false;
        winCondition = false;
        SetConstraints();
    }

    public void Update()
    {
        GetInput();
        CheckWin();
    }

    private void CheckWin()
    {
        int i = 0;
        foreach (var target in targets)
        {
            if (target.playerOnTarget)
            {
                i++;
            }
        }
        if (i >= targets.Count)
        {
            winCondition = true;
        }
    }

    private void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (actualPlayer <= 0)
            {
                actualPlayer = players.Count - 1;
                SetConstraints();
            }
            else
            {
                actualPlayer--;
                SetConstraints();
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (actualPlayer >= players.Count - 1)
            {
                actualPlayer = 0;
                SetConstraints();
            }
            else
            {
                actualPlayer++;
                SetConstraints();
            }
        }
    }

    private void SetConstraints()
    {
        foreach (var player in players)
        {
            if (player == players[actualPlayer])
            {
                player.rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            }
            else
            {
                player.rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            }
        }
    }
}
