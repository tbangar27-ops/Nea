using UnityEngine;

public class CandleScript : MonoBehaviour
{
    bool isPlayer = false;
    private Collider playerCollider;
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
        }}
    public void Update() {
        if (Input.GetKeyDown(KeyCode.E) && isPlayer == true)
        {
            Transform parentTransform = playerCollider.transform.parent;
            parentTransform.Find("PlayerCandle").gameObject.SetActive(true);
            Destroy(transform.parent.gameObject);
        }
    }
    }