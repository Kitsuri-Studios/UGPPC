using UnityEngine;

public class FirstPersonnPlayerController : MonoBehaviour
{
    int RightFingerId = -1;
    int LeftFingerId = -1;
    private Vector2 MoveDelta;
    private Vector2 LookDelta;
    public float MoveSpeed = 10f;
    public float CameraSenstivity = 1.0f;
    private float pitch;
    CharacterController characterController;
    public Transform Camera;
    float HalfScreenSize;

    void Start()
    {
        HalfScreenSize = Screen.width * 0.5f;
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        HandleTouchInput();
    }

    void PlayerCharacterCameraHandling()
    {
        pitch -= LookDelta.y * CameraSenstivity;
        pitch  = Mathf.Clamp(pitch, -90, 90f);

        Camera.localRotation = Quaternion.Euler(pitch, 0, 0);
        transform.Rotate(Vector3.up, LookDelta.x * CameraSenstivity);
    }

    void PlayerCharacterMovementHandling()
    {
        Vector3 move = transform.forward * MoveDelta.y + transform.right * MoveDelta.x;
        
        characterController.Move(move * MoveSpeed * Time.deltaTime);
    }

    void HandleTouchInput()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                if (touch.position.x < HalfScreenSize && LeftFingerId == -1)
                    LeftFingerId = touch.fingerId;

                else if (touch.position.x >= HalfScreenSize && RightFingerId == -1)
                    RightFingerId = touch.fingerId;
            }

            if (touch.fingerId == LeftFingerId)
            {
                MoveDelta = touch.deltaPosition;
            }

            if (touch.fingerId == RightFingerId)
            {
                LookDelta = touch.deltaPosition;
            }

            if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                if (touch.fingerId == LeftFingerId) LeftFingerId = -1;
                if (touch.fingerId == RightFingerId) RightFingerId = -1;
            }
        }
    }
}