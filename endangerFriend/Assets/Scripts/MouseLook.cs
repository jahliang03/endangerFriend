using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [Header("Mouse Sensitivity")]
    public float mouseSensitivity = 200f;

    private Transform playerBody;
    private float xRotation = 0f;

    private void Start()
    {
        // Lock the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;

        // Reference to the Player body (parent)
        playerBody = transform.parent;
    }

    private void Update()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotate the player body around the Y axis (horizontal rotation)
        playerBody.Rotate(Vector3.up * mouseX);

        // Rotate the camera holder around the X axis (vertical rotation)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Apply the rotation to the camera holder itself
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
