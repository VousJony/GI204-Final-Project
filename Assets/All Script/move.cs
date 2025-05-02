using UnityEngine;

public class move : MonoBehaviour
{
    public float moveSpeed = 5f;    // ความเร็วในการเดิน
    public float jumpForce = 7f;    // แรงกระโดด
    public Transform groundCheck;   // จุดตรวจสอบว่าตัวละครอยู่บนพื้นหรือไม่
    public LayerMask groundLayer;   // เลเยอร์ของพื้น

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // ตรวจสอบว่าอยู่บนพื้นหรือไม่
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        // รับค่าเดินซ้ายขวา
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // พลิกตัวละครตามทิศทางที่เดิน
        if (moveInput > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);  // หันขวา
        }
        else if (moveInput < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);  // หันซ้าย
        }

        // กระโดดเมื่อกด Space และอยู่บนพื้น
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    // ฟังก์ชันที่ทำงานเมื่อชนกับ collider
    void OnCollisionEnter2D(Collision2D collision)
    {
        // ตรวจสอบว่า collider ที่ชนมี tag "Apple"
        if (collision.gameObject.CompareTag("Apple"))
        {
            // ลบวัตถุที่มี Tag "Apple"
            Debug.Log("ตัวละครชนกับ Apple และกำลังลบ Apple...");
            Destroy(collision.gameObject);  // ลบวัตถุที่มี Tag "Apple"
        }
    }

    // ถ้าใช้ Trigger (แทนการชนแบบ Collision)
    void OnTriggerEnter2D(Collider2D other)
    {
        // ตรวจสอบว่า collider ที่ชนมี tag "Apple"
        if (other.CompareTag("Apple"))
        {
            // ลบวัตถุที่มี Tag "Apple"
            Destroy(other.gameObject);  // ลบวัตถุที่มี Tag "Apple"
        }
    }
}
