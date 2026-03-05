using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Transform orientation;
    float horizontalInput;
    float verticalInput;
    public Rigidbody rb;
    Vector3 direction;
    public float Drag;
    public KeyCode sprintKey = KeyCode.LeftShift;
    public float SprintSpeed;
    public float WalkSpeed;
    public PlayerState Pstate;
    public bool HasKeyRed = false;
    public bool HasKeyBlue = false;
    public bool HasKeyYellow = false;
    
    public enum PlayerState
    {
    Walking,
    Sprinting,
    }

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

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }
    private void Movement()
    {
        direction = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(direction.normalized * speed, ForceMode.Force);

    }
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

