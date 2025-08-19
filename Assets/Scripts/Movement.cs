using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] GameManager gm;

    private Vector2 moveInput;
    private Rigidbody2D rb;
    private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        float moveMultiplier = gm.GetCurrentStamina() > 0 ? moveSpeed : moveSpeed / 2f;
        rb.velocity = moveInput * moveMultiplier;
        AnimateMovement();
    }

    void AnimateMovement()
    {
        if (animator != null)
        {
            if (moveInput.magnitude > 0)
            {
                gm.DrainStamina();
                animator.SetBool("isMoving", true);
                animator.SetFloat("horizontal", moveInput.x);
                animator.SetFloat("vertical", moveInput.y);
            }
            else
            {
                gm.StartRegen(2f, 5f);
                animator.SetBool("isMoving", false);
            }
        }
    }
}
