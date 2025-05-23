using UnityEngine;

public class RigidbodyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private float groundCheckDistance = 0.2f;
    
    private Rigidbody rb;
    private Vector3 moveInput;
    private bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Предотвращаем нежелательное вращение
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        moveInput = new Vector3(horizontal, 0, vertical).normalized;
        
        if (moveInput.magnitude > 0.1f)
        {
            float targetAngle = Mathf.Atan2(moveInput.x, moveInput.z) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        // Проверка земли
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance);
        
        // Движение
        Vector3 moveVelocity = transform.forward * moveInput.magnitude * moveSpeed;
        moveVelocity.y = rb.linearVelocity.y; // Сохраняем вертикальную скорость
        rb.linearVelocity = moveVelocity;
    }
}