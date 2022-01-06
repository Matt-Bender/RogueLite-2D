using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BasicPlatform : MonoBehaviour
{
    PlayerInput playerInput;
    private InputAction dropAction;

    private PlatformEffector2D effector;

    private bool playerOnPlatform = false;

    private void Awake()
    {
        playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
        dropAction = playerInput.actions["Drop"];
        effector = GetComponent<PlatformEffector2D>();
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
        if (dropAction.triggered && playerOnPlatform)
        {
            effector.rotationalOffset = 180;
            Invoke("CancelDrop", .4f);
        }
    }

    private void CancelDrop()
    {
        effector.rotationalOffset = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = false;
        }
    }
}
