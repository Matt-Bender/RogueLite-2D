using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    GameObject player;

    [SerializeField] private float smoothTime;
    [SerializeField] private Vector3 offset;
    private Vector3 velocity = Vector3.zero;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Start is called before the first frame update
    void Start()
    {
        if(player == null)
        {
            Debug.LogWarning("Camera cannot find player object");
        }
    }

    private void FixedUpdate()
    {
        Vector3 desiredPosition = player.transform.position + offset;
        //Smoothing every coordinate x/y
        //transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);
        //Smoothing only x
        transform.position = new Vector3(Mathf.SmoothDamp(transform.position.x, desiredPosition.x, ref velocity.x, smoothTime), transform.position.y, transform. position.z);
    }
}
