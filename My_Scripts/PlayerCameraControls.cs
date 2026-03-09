using UnityEngine;

// This script controls the player's camera with mouse look functionality
public class PlayerCameraControls : MonoBehaviour
{

    // Current X rotation of the camera
    float Xrotation;
    // Current Y rotation of the camera
    float Yrotation;
    // Transform of the player's body to rotate
    public Transform BodyRotate;
    // Sensitivity for X axis mouse movement
    public float Xsens;
    // Sensitivity for Y axis mouse movement
    public float Ysens;
    // Initialize cursor settings
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update camera rotation based on mouse input
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Xsens;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Ysens;

        Yrotation += mouseX;
        Xrotation -= mouseY;
        Xrotation = Mathf.Clamp(Xrotation, -80f, 80f);


        transform.rotation = Quaternion.Euler(Xrotation, Yrotation, 0);
        BodyRotate.rotation = Quaternion.Euler(0 , Yrotation, 0);

    }
}
