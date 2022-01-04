using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D playerRB;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BasicMovement(InputAction.CallbackContext context)
    {
        Vector2 inputMovement;
        if (context.performed)
        {
            Debug.Log("Move");
            inputMovement = context.ReadValue<Vector2>();
            playerRB.velocity = inputMovement;
        }
        
    }
}
