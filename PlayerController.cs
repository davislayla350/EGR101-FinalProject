using UnityEngine;

//didnt use alpot of the disables due to errors i didnt wanna fix
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed, jumpSpeed;
    [SerializeField] private LayerMask ground;

    private PlayerControls playerControls;  //issues with name errors?
    private Rigidbody2D rb;
    private Collider2D col;
    private Animator animator;

    public bool canMove = true; // Flag to control movement ended up not using too much work

    private void Awake()
    {
        playerControls = new PlayerControls();  // Initialize the player controls
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        playerControls.Enable();  // Enable the controls when the script is enabled
        playerControls.Land.Jump.performed += _ => Jump();  // Bind the jump action (+)
    }

    private void OnDisable()
    {
        playerControls.Disable();  // Disable controls when the script is disabled didn't use
        playerControls.Land.Jump.performed -= _ => Jump();  // Unbind the jump action (-)
    }

    private void Jump()
    {
        if (!canMove) return; // Prevent jumping if canMove is false
        Debug.Log("Jumping");
        rb.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
        animator.SetTrigger("Move");
    }

    void Update()
    {
        if (canMove) // Only move if canMove is true
        {
            Move();
        }
    }

    private void Move()
    {
        Debug.Log("Move is running"); // wasnt moving before 

        float movementInput = playerControls.Land.Move.ReadValue<float>();  // Get movement input

        // Flip the sprite based on movement direction
        if (movementInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);  // Face right
        }
        else if (movementInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);  // Face left
        }

        Vector3 currentPosition = transform.position;
        currentPosition.x += movementInput * speed * Time.deltaTime;  // Update position
        transform.position = currentPosition;

        // Update animation state
        animator.SetBool("Move", movementInput != 0);
    }
}
