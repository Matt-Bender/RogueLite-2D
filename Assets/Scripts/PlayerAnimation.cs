using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimation : MonoBehaviour
{
    PlayerInput playerInput;
    private InputAction dropAction;

    Animator playerAnim;
    PlayerMovement playerMovementScript;
    // Start is called before the first frame update
    void Start()
    {
        playerInput = gameObject.GetComponent<PlayerInput>();
        dropAction = playerInput.actions["Drop"];

        playerMovementScript = gameObject.GetComponent<PlayerMovement>();
        playerAnim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dropAction.triggered)
        {
            playerAnim.SetTrigger("drop");
        }
        playerAnim.SetInteger("moveDirection", playerMovementScript.GetMoveHorizontal());
    }
}
