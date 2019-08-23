using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField, Range(0.1f, 10f)]
    float moveSpeed;

    Animator animator;
    SpriteRenderer spriteRenderer;

    bool moving;

    void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector2 axis = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        transform.Translate(axis * moveSpeed * Time.deltaTime);
        moving = axis != Vector2.zero;

        if(moving)
        {
            animator.SetFloat("move-X", axis.x);
            animator.SetFloat("move-Y", axis.y);
        }

        animator.SetBool("moving", moving);

        spriteRenderer.flipX = axis.x < 0 ? true : axis.x > 0 ? false : spriteRenderer.flipX;
    }
}
