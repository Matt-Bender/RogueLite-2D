using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    Animator enemyAnim;

    [SerializeField] private int speed;
    private Vector2 direction = Vector2.right;
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        enemyAnim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Patrol"))
        {
            if(direction == Vector2.right)
            {
                direction = Vector2.left;
                sprite.flipX = true;
            }
            else
            {
                direction = Vector2.right;
                sprite.flipX = false;
            }
        }
    }
}
