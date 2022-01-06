using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D playerRB;
    PlayerInput playerInput;

    [Header("Movement")]
    [SerializeField] private int speed;
    Vector2 inputMovement = Vector2.zero;
    private float moveHorizontal;
    private InputAction moveAction;
    
    [Header("Jump")]
    [SerializeField] private int jumpForce;
    private Vector3 jumpDirection = new Vector3(0, 2, 0);
    private InputAction jumpAction;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>(); ;
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];
    }

    // Update is called once per frame
    void Update()
    {
        if (jumpAction.triggered)
        {
            playerRB.AddForce(jumpForce * jumpDirection, ForceMode2D.Force);
        }
    }
    private void FixedUpdate()
    {
        //inputMovement.y = 0;
        float moveHorizontal = moveAction.ReadValue<float>();
        Debug.Log(moveHorizontal);
        playerRB.velocity = new Vector2(moveHorizontal * speed, playerRB.velocity.y);
    }

    //public void BasicMovement(InputAction.CallbackContext context)
    //{
    //    //moveHorizontal = context.ReadValue<float>();
        
        
    //    //inputMovement = context.ReadValue<Vector2>();
    //    //if (context.performed)
    //    //{
    //    //    Debug.Log("Move");
    //    //}
        
    //}

    //public void Jump(InputAction.CallbackContext context)
    //{
    //    if (context.performed)
    //    {
    //        Debug.Log("Jump");
    //        playerRB.AddForce(jumpForce * jumpDirection, ForceMode2D.Force);
    //    }
    //}
}
