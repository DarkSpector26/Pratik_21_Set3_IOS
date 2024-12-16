using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    // Movement speed of the player
    public float speed = 6.0f;
    // Jump speed of the player
    public float jumpSpeed = 8.0f;
    // Gravity applied to the player
    public float gravity = 20.0f;
    // Sensitivity of the mouse for camera rotation
    public float mouseSensitivity = 100.0f;

    private Vector3 moveDirection = Vector3.zero; // Direction in which the player is moving
    private CharacterController controller; // Reference to the CharacterController component
    private float rotationY = 0.0f; // Rotation around the Y axis for camera movement
    private Camera _Camera; // Reference to the main camera
 // Reference to the PhotonView component for network ownership

    void Start()
    {
        // Initialize the camera and CharacterController components
        _Camera = Camera.main;
        controller = GetComponent<CharacterController>();
       

        // Optionally lock the cursor in the center of the screen
        // Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Ensure only the local player controls their character
       
        
           

            // Rotate the player based on mouse movement
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            rotationY += mouseX;
            transform.localRotation = Quaternion.Euler(0.0f, rotationY, 0.0f);

            if (controller.isGrounded)
            {
                // Get input for horizontal and vertical movement
                float moveHorizontal = Input.GetAxis("Horizontal");
                float moveVertical = Input.GetAxis("Vertical");

                // Calculate movement direction and apply speed
                moveDirection = new Vector3(moveHorizontal, 0.0f, moveVertical);
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;

                // Handle jumping
                if (Input.GetButton("Jump"))
                {
                    moveDirection.y = jumpSpeed;
                }
            }

            // Apply gravity to the movement direction
            moveDirection.y -= gravity * Time.deltaTime;

            // Move the character controller
            controller.Move(moveDirection * Time.deltaTime);
        
    }
}
