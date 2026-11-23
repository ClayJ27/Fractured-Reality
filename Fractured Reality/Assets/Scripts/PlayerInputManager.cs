using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{

    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform[] spawnPoints;


    private bool keyboardJoined = false;
    private bool gamepadJoined = false;


    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current == null) return;

        if (!keyboardJoined && Keyboard.current.enterKey.wasPressedThisFrame)
        {
            var player = PlayerInput.Instantiate(playerPrefab, controlScheme: "Keyboard", pairWithDevice: Keyboard.current);
            if (spawnPoints.Length > 0)
            {
                player.transform.position = spawnPoints[0].position;
            }

            keyboardJoined = true;
        }

        foreach (var gamePad in Gamepad.all)
        {
            if (!gamepadJoined && gamePad.startButton.wasPressedThisFrame)
            {
                var player = PlayerInput.Instantiate(playerPrefab, controlScheme: "Gamepad", pairWithDevice: gamePad);
                if (spawnPoints.Length > 1)
                {
                    player.transform.position = spawnPoints[1].position;
                }
                gamepadJoined = true;
            }
        }
    }
}
