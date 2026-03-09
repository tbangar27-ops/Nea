using UnityEngine;

// This script handles door interaction and opening/closing based on player keys
public class DoorScript : MonoBehaviour
{
    // Type of door this script represents
    public GameBehaviour.DoorType MyDtype;
    // Transform of the door object
    public Transform DoorT; 
    // Whether the door is currently open
    bool isOpen = false;
    // Time of last toggle action
    float lastToggleTime = 0f;
    // Cooldown time between toggles
    public float toggleCooldown = 1f;
    // Original rotation of the door
    private Quaternion originalRotation;
    // Original position of the door
    private Vector3 originalPosition;
    // Whether the player is in range
    bool isPlayer = false;
    // Reference to the player's collider
    private Collider playerCollider;


    // Initialize door's original position and rotation
    private void Start()
    {
        originalRotation = DoorT.rotation;
        originalPosition = DoorT.position;
    }
    // Called when a collider enters the trigger
    public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            isPlayer = true;
            playerCollider = other;
        }
    }

    // Called when a collider exits the trigger
    public void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            isPlayer = false;
            playerCollider = null;
        }
    }
    // Check for door interaction input
    public void Update() {
        if (Input.GetKeyDown(KeyCode.E) && isPlayer == true) {
            DoorLogic();
        }
    }
    // Logic for opening or closing the door based on key possession
    void DoorLogic()
    {
            PlayerMovement DoesKey = playerCollider.GetComponentInParent<PlayerMovement>();
            if (MyDtype == GameBehaviour.DoorType.Red)
            {
                if (DoesKey.HasKeyRed == true)
                {
                    if(isOpen == false){
                        opendoor();
                    }
                    else{
                        closedoor();
                    }
                }
            }
            else if (MyDtype == GameBehaviour.DoorType.Blue)
            {
                if (DoesKey.HasKeyBlue == true)
                {
                    if(isOpen == false){
                        opendoor();
                    }
                    else{
                        closedoor();
                    }
                }
            }
            else if (MyDtype == GameBehaviour.DoorType.Yellow)
            {
                if (DoesKey.HasKeyYellow == true)
                {
                    if(isOpen == false){
                        opendoor();
                    }
                    else{
                        closedoor();
                    }
                }
            }
        }

    // Open the door
    void opendoor()
    {
        if (isOpen == false && Time.time - lastToggleTime > toggleCooldown)
        {
            DoorT.rotation = originalRotation * Quaternion.Euler(0, 90, 0);
            DoorT.position = new Vector3(originalPosition.x - 0.5f * DoorT.localScale.x, originalPosition.y, originalPosition.z);
            isOpen = true;
            lastToggleTime = Time.time;
        }
    }
    // Close the door
    public void closedoor()
    {
        if (isOpen == true && Time.time - lastToggleTime > toggleCooldown)
        {
            DoorT.rotation = originalRotation;
            DoorT.position = originalPosition;
            isOpen = false;
            lastToggleTime = Time.time;
        }
    }
}
