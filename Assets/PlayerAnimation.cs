using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator playerAnim;
    PlayerMovement playerMovementScript;
    // Start is called before the first frame update
    void Start()
    {
        playerMovementScript = gameObject.GetComponent<PlayerMovement>();
        playerAnim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(playerMovementScript.GetMoveHorizontal());
        playerAnim.SetInteger("moveDirection", playerMovementScript.GetMoveHorizontal());
    }
}
