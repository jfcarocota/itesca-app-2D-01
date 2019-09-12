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
    Player target;

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
        moving = Vector2.Distance(target.transform.position, transform.position) > minDistanceFollow;
        if(moving)
        {
            npcDirection = target.transform.position - transform.position;
            npcDirection.Normalize();
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
            animator.SetFloat("move-X", npcDirection.x);
            animator.SetFloat("move-Y", npcDirection.y);
        }
    }

    protected void Update()
    {
        animator.SetBool("moving", moving);
        spriteRenderer.flipX = Axis.x < 0 ? true : Axis.x > 0 ? false : spriteRenderer.flipX;
    }

    void OnCollisionEnter2D(Collision2D col2d)
    {
        if(col2d.collider.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(col2d.collider, collider2D);
        }
    }

    public Player Target
    {
        get => target;
        set => target = value;
    }

    protected Vector2 Axis
    {   
        get => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
    }
}
