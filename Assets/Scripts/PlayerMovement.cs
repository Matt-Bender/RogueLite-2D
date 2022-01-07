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

    [Header("Grounded")]
    [SerializeField] private bool isGrounded;
    [SerializeField] private LayerMask isGroundLayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius;

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
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGroundLayer);
        
        if (jumpAction.triggered && isGrounded)
        {
            playerRB.AddForce(jumpForce * jumpDirection, ForceMode2D.Force);
        }
    }
    //Debug to view size of groundcheck
    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawSphere(groundCheck.position, groundCheckRadius);
    //}
    private void FixedUpdate()
    {
        moveHorizontal = moveAction.ReadValue<float>();
        playerRB.velocity = new Vector2(moveHorizontal * speed, playerRB.velocity.y);
    }

    public int GetMoveHorizontal()
    {
        return (int)moveHorizontal;
    }

    public bool GetIsGrounded()
    {
        return isGrounded;
    }
}
