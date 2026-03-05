using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KeyScript : MonoBehaviour
{
    bool isPlayer = false;
    private Collider playerCollider;
    public GameBehaviour.KeyType KType;

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
        if (Input.GetKeyDown(KeyCode.E) && isPlayer) {
            PickUpKey();
        }
    }

    private void PickUpKey() {
        PlayerMovement Pmovement = playerCollider.GetComponentInParent<PlayerMovement>();
        if(KType == GameBehaviour.KeyType.RedKey)
        {
            Pmovement.HasKeyRed = true;
        }
        else if(KType == GameBehaviour.KeyType.BlueKey)
        {
            Pmovement.HasKeyBlue = true;
        }
        else if(KType == GameBehaviour.KeyType.YellowKey)
        {
            Pmovement.HasKeyYellow = true;
        }
        Destroy(transform.parent.gameObject);
    }

}
