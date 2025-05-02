using UnityEngine;

public class detect : MonoBehaviour
{
    // เรียกใช้เมื่อมีการชนกันเกิดขึ้น
    void OnCollisionEnter2D(Collision2D collision)
    {
        // ตรวจสอบว่าตัวที่ชนเป็น Bullet และ Enemy หรือไม่
        if (collision.gameObject.CompareTag("Bullet") && gameObject.CompareTag("Ground"))
        {
            // ลบ Bullet และ Enemy
            Destroy(collision.gameObject);  // ลบ Bullet
            Destroy(gameObject);  // ลบ Enemy
        }
    }
}