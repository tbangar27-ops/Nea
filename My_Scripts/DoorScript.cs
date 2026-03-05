using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public GameBehaviour.DoorType MyDtype;
    public Transform DoorT; 
    bool isOpen = false;
    float lastToggleTime = 0f;
    public float toggleCooldown = 1f;
    private Quaternion originalRotation;
    private Vector3 originalPosition;
    bool isPlayer = false;
    private Collider playerCollider;


    private void Start()
    {
        originalRotation = DoorT.rotation;
        originalPosition = DoorT.position;
    }
    public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            isPlayer = true;
            playerCollider = other;
        }
    }

    public void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            isPlayer = false;
            playerCollider = null;
        }
    }
    public void Update() {
        if (Input.GetKeyDown(KeyCode.E) && isPlayer == true) {
            DoorLogic();
        }
    }
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
