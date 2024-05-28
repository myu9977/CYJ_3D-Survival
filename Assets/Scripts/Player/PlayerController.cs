using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header(" Movement ")]
    public float moveSpeed;
    private Vector2 curMovementInput;

    [Header(" Look ")]
    public Transform cameraContainer;
    public float minXLook;
    public float maxXLook;
    private float camCurXRop;
    public float lookSensitivity;
    private Vector2 mouseDelta;
    //public bool canLook = true;

    private Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        // 마우스 커서 숨기기
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        Move();
    }

    private void LateUpdate()
    {
        CameraLook();
    }

    private void Move()
    {
        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
        dir *= moveSpeed;
        dir.y = rigidbody.velocity.y;

        rigidbody.velocity = dir;
    }

    private void CameraLook()
    {
        camCurXRop += mouseDelta.y * lookSensitivity;
        camCurXRop = Mathf.Clamp(camCurXRop, minXLook, maxXLook);
        cameraContainer.localEulerAngles = new Vector3(-camCurXRop, 0, 0);

        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            curMovementInput = context.ReadValue<Vector2>();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }
}
