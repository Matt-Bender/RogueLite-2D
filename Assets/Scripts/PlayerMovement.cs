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
    private bool isGrounded;
    [SerializeField] private LayerMask isGroundLayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius;

    [Header("Dash")]
    [SerializeField] private float dashDistance;
    [SerializeField] private float dashCooldown;
    private float dashTime;
    private InputAction dashAction;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>(); ;
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];
        dashAction = playerInput.actions["Dash"];
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGroundLayer);

        if (jumpAction.triggered && isGrounded)
        {
            playerRB.AddForce(jumpForce * jumpDirection, ForceMode2D.Force);
        }
        if (dashAction.triggered)
        {
            if (Time.time - dashTime >= dashCooldown)
            {
                dashTime = Time.time;
                if (moveHorizontal > 0)
                {
                    transform.position += new Vector3(dashDistance, 0, 0);
                }
                else if (moveHorizontal < 0)
                {
                    transform.position += new Vector3(-dashDistance, 0, 0);
                }
                dashTime = Time.time;
            } 
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
