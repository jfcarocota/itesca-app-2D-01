using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.BasicInput;

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

    [SerializeField]
    float minDist;

    void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2D = GetComponent<Collider2D>();
    }

    protected void Update()
    {
        if(moving)
        {
            animator.SetFloat("move-X", BasicInput.AxisNormalized.x);
            animator.SetFloat("move-Y", BasicInput.AxisNormalized.y);
        }

        animator.SetBool("moving", moving);

        spriteRenderer.flipX = BasicInput.AxisNormalized.x < 0 ? true : BasicInput.AxisNormalized.x > 0 ? false : spriteRenderer.flipX;
    }

    public virtual void Movement()
    {
        moving = Vector2.Distance(leader.transform.position, transform.position) > minDist;
        if(moving)
        {
            transform.position = Vector2.MoveTowards(transform.position, leader.transform.position, moveSpeed * Time.deltaTime);
        }
    }


    public Player Leader
    {
        get => leader;
        set => leader = value;
    }

    public Collider2D Collider2D
    {
        get => collider2D;
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(collider2D, other.collider);
        }
    }
}
