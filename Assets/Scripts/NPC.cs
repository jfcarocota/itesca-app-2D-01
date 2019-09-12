using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
   [SerializeField, Range(0.1f, 10f)]
    protected float moveSpeed;

    protected Animator animator;
    protected SpriteRenderer spriteRenderer;
    protected Collider2D collider2D;

    protected bool moving;

    [SerializeField]
    Player leader;

    [SerializeField, Range(0.1f, 5f)]
    float minDistanceFollow;
    

    Vector2 npcDirection;
    
    void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2D = GetComponent<Collider2D>();
    }

    public virtual void Move()
    {
        moving = Vector2.Distance(leader.transform.position, transform.position) > minDistanceFollow;
        if(moving)
        {
            npcDirection = leader.transform.position - transform.position;
            npcDirection.Normalize();
            transform.position = Vector2.MoveTowards(transform.position, leader.transform.position, moveSpeed * Time.deltaTime);
            animator.SetFloat("move-X", npcDirection.x);
            animator.SetFloat("move-Y", npcDirection.y);
        }
    }

    protected void Update()
    {
        animator.SetBool("moving", moving);
        spriteRenderer.flipX = leader.Axis.x < 0 ? true : leader.Axis.x > 0 ? false : spriteRenderer.flipX;
    }

    void OnCollisionEnter2D(Collision2D col2d)
    {
        if(col2d.collider.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(col2d.collider, collider2D);
        }
    }
}
