using UnityEngine;

public class WinScript : MonoBehaviour
{
    public void OnTriggerEnter(Collider other) {
        UnityEngine.SceneManagement.SceneManager.LoadScene("WinScene");
    }
}
