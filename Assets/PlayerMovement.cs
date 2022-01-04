using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D playerRB;

    [Header("Movement")]
    [SerializeField] private int speed;
    Vector2 inputMovement = Vector2.zero;
    private float moveHorizontal;
    
    [Header("Jump")]
    [SerializeField] private int jumpForce;
    private Vector3 jumpDirection = new Vector3(0, 2, 0);

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        //inputMovement.y = 0;
        playerRB.velocity = new Vector2(moveHorizontal * speed, playerRB.velocity.y);
    }

    public void BasicMovement(InputAction.CallbackContext context)
    {
        moveHorizontal = context.ReadValue<float>();
        Debug.Log(moveHorizontal);
        //inputMovement = context.ReadValue<Vector2>();
        //if (context.performed)
        //{
        //    Debug.Log("Move");
        //}
        
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Jump");
            playerRB.AddForce(jumpForce * jumpDirection, ForceMode2D.Force);
        }
    }
}
