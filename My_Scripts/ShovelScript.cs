using UnityEngine;

public class ShovelScript : MonoBehaviour
{
    public GameBehaviour.DoorType MyDtype;
    public Transform DoorT; 
    private Collider playerCollider;
    public bool IsAxe = false;
    public GameObject Axe;

    // tracks whether the player is inside the trigger
    private bool isPlayer = false;

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
if (Input.GetKeyDown(KeyCode.E) && isPlayer)
            {
                if (playerCollider.GetComponentInParent<PlayerMovement>().HasKeyRed == true)
                {
                    Destroy(transform.parent.gameObject);
                    if (IsAxe)
                    {
                        Axe.SetActive(true);
                    }
                }
            }
        }
    }

