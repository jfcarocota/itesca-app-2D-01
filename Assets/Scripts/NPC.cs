using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
   [SerializeField, Range(0.1f, 10f)]
    protected float moveSpeed;

    protected Animator animator;
    protected SpriteRenderer spriteRenderer;

    protected bool moving;

    [SerializeField]
    Player leader;

    [SerializeField, Range(0.1f, 5f)]
    float minDistanceFollow;
    
    
    void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public virtual void Move()
    {
        moving = Vector2.Distance(leader.transform.position, transform.position) > minDistanceFollow;
        if(moving)
        {
            transform.position = Vector2.MoveTowards(transform.position, leader.transform.position, moveSpeed * Time.deltaTime);
            animator.SetFloat("move-X", leader.Axis.x);
            animator.SetFloat("move-Y", leader.Axis.y);
        }
        animator.SetBool("moving", moving);
    }

    protected void Update()
    {
        spriteRenderer.flipX = leader.Axis.x < 0 ? true : leader.Axis.x > 0 ? false : spriteRenderer.flipX;
    }
}
