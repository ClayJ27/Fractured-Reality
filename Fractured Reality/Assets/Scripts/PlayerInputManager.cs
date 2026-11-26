using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerInputManager : MonoBehaviour
{

    public Transform[] spawnPoints;
    private int m_playerCount;


    public void OnPlayerJoined(PlayerInput playerInput)
    {
        playerInput.transform.position = spawnPoints[m_playerCount].transform.position;
        if (m_playerCount == 0 )
        {
            playerInput.GetComponent<Rigidbody2D>();
        }
        m_playerCount++;

    }
}
