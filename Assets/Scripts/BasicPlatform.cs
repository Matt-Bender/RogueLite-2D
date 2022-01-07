using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BasicPlatform : MonoBehaviour
{
    PlayerInput playerInput;
    private InputAction dropAction;

    private PlatformEffector2D effector;

    PlayerOnPlatform onPlatformScript;

    private void Awake()
    {
        playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
        dropAction = playerInput.actions["Drop"];
        effector = GetComponent<PlatformEffector2D>();
        onPlatformScript = GetComponentInChildren<PlayerOnPlatform>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if(playerInput == null)
        {
            Debug.LogWarning(gameObject.name + "Missing reference to playerInput component");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (dropAction.triggered && onPlatformScript.GetOnPlatform())
        {
            effector.rotationalOffset = 180;
            Invoke("CancelDrop", .4f);
        }
    }

    private void CancelDrop()
    {
        effector.rotationalOffset = 0;
    }
}
