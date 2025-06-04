using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        moveInput = new Vector2(inputX, inputY).normalized;

        animator.SetFloat("MoveX", inputX);
        animator.SetFloat("MoveY", inputY);

        if (moveInput.magnitude > 0.01f)
        {
            animator.SetBool("IsMoving", true);

            // 가장 뚜렷한 방향만 반영
            if (Mathf.Abs(inputX) > Mathf.Abs(inputY))
            {
                animator.SetFloat("LastMoveX", inputX > 0 ? 1 : -1);
                animator.SetFloat("LastMoveY", 0);
            }
            else
            {
                animator.SetFloat("LastMoveX", 0);
                animator.SetFloat("LastMoveY", inputY > 0 ? 1 : -1);
            }
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    }
}
