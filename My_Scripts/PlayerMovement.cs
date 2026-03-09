using UnityEngine;
using TMPro;

// This script controls the player's movement, including walking, sprinting, and key inventory
public class PlayerMovement : MonoBehaviour
{
    // Movement speed
    public float speed;
    // Player's orientation transform
    public Transform orientation;
    // Horizontal input from player
    float horizontalInput;
    // Vertical input from player
    float verticalInput;
    // Rigidbody component for physics
    public Rigidbody rb;
    // Movement direction vector
    Vector3 direction;
    // Drag value for rigidbody
    public float Drag;
    // Key for sprinting
    public KeyCode sprintKey = KeyCode.LeftShift;
    // Speed when sprinting
    public float SprintSpeed;
    // Speed when walking
    public float WalkSpeed;
    // Current player state
    public PlayerState Pstate;
    // Whether player has red key
    public bool HasKeyRed = false;
    // Whether player has blue key
    public bool HasKeyBlue = false;
    // Whether player has yellow key
    public bool HasKeyYellow = false;
    
    // Enum for player states
    public enum PlayerState
    {
    Walking,
    Sprinting,
    }

    // Initialize rigidbody settings
    void Start()
    {
        rb.freezeRotation = true;
        rb.linearDamping = Drag;
    }

    // Update is called once per frame
    void Update()
    {
        MyInput();
        Movement();
        SpeedController();
        StateHandler();
    }

    // Get player input
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }
    // Apply movement force
    private void Movement()
    {
        direction = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(direction.normalized * speed, ForceMode.Force);

    }
    // Handle player state changes
    private void StateHandler()
    {
        if(Input.GetKey(sprintKey))
        {
            Pstate = PlayerState.Sprinting;
            speed = SprintSpeed;
        }
        else
        {
            Pstate = PlayerState.Walking;
            speed = WalkSpeed;
        }
    }


    // Control maximum speed
    private void SpeedController()
    {
        Vector3 Value = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        if(Value.magnitude > speed)
        {
            Vector3 NewVal = Value.normalized * speed;
            rb.linearVelocity = new Vector3(NewVal.x, rb.linearVelocity.y , NewVal.z );
        }
    }

}

