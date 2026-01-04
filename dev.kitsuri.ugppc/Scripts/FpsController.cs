using UnityEngine;


namespace UGPPC.dev.kitsuri.ugppc
{
    [RequireComponent(typeof(CharacterController))]
    public class MobileFPSController : MonoBehaviour
{
    [Header("References")]
    public Transform cameraTransform;
    public JoystickController joystick;

    [Header("Movement")]
    public float moveSpeed = 5f;
    public float gravity = -9.8f;

    [Header("Look")]
    public float lookSensitivity = 0.15f;
    public float maxLookAngle = 80f;

    CharacterController controller;
    Vector3 velocity;

    float pitch;
    float halfScreen;

    int lookFingerId = -1;
    Vector2 lookDelta;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        halfScreen = Screen.width * 0.5f;
    }

    void Update()
    {
        HandleLookInput();
        HandleMovement();
    }
    void HandleLookInput()
    {
        lookDelta = Vector2.zero;

        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began &&
                touch.position.x > halfScreen &&
                lookFingerId == -1)
            {
                lookFingerId = touch.fingerId;
            }

            if (touch.fingerId == lookFingerId)
            {
                lookDelta = touch.deltaPosition;
            }

            if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                if (touch.fingerId == lookFingerId)
                    lookFingerId = -1;
            }
        }
        pitch -= lookDelta.y * lookSensitivity;
        pitch = Mathf.Clamp(pitch, -maxLookAngle, maxLookAngle);

        cameraTransform.localRotation = Quaternion.Euler(pitch, 0f, 0f);
        transform.Rotate(Vector3.up * lookDelta.x * lookSensitivity);
    }
    
    void HandleMovement()
    {
        Vector3 move =
            transform.forward * joystick.InputVector.y +
            transform.right * joystick.InputVector.x;

        controller.Move(move * moveSpeed * Time.deltaTime);
        
        if (controller.isGrounded && velocity.y < 0)
            velocity.y = -2f;

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}

}
