using UnityEngine;

public class ScareScript : MonoBehaviour
{
    public GameObject Scare;
    void OnTriggerEnter(Collider other)
    {
        Scare.SetActive(true);
        Invoke("End",1f);
    }
    void End()
    {
        Scare.SetActive(false);
    }
}
