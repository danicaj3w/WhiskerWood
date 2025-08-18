using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] Stamina staminaBar;

    private Vector2 moveInput;
    private Rigidbody2D rb;
    private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        if (staminaBar == null)
        {
            Debug.LogWarning("Movement: Missing stamina bar!");
        }
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        float moveMultiplier = staminaBar.GetCurrentStamina() > 0 ? moveSpeed : moveSpeed / 2f;
        rb.velocity = moveInput * moveMultiplier;
        AnimateMovement();
    }

    void AnimateMovement()
    {
        if (animator != null)
        {
            if (moveInput.magnitude > 0)
            {
                staminaBar.DrainStamina();
                animator.SetBool("isMoving", true);
                animator.SetFloat("horizontal", moveInput.x);
                animator.SetFloat("vertical", moveInput.y);
            }
            else
            {
                animator.SetBool("isMoving", false);
                staminaBar.StartRegen();
            }
        }
    }
}
