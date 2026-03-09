using UnityEngine;

// This script handles scare events by activating a scare object temporarily
public class ScareScript : MonoBehaviour
{
    // The scare object to activate
    public GameObject Scare;
    // Called when a collider enters the trigger
    void OnTriggerEnter(Collider other)
    {
        Scare.SetActive(true);
        Invoke("End",1f);
    }
    // Deactivate the scare object
    void End()
    {
        Scare.SetActive(false);
    }
}
