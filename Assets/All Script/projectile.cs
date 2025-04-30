using UnityEngine;

public class projectile : MonoBehaviour
{
    public Transform shootPoint;  // จุดที่กระสุนจะถูกยิงออกมา
    public GameObject target;     // เป้าหมายที่กระสุนยิงไป
    public Rigidbody2D bulletPrefab;  // กระสุน prefab

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // แปลงตำแหน่งเมาส์ในจอ เป็นตำแหน่งในโลก 2D
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 5f, Color.magenta, 5f);

            // คำนวณตำแหน่งของเป้าหมายที่คลิก
            Vector2 targetPosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // ย้าย Target ไปที่ตำแหน่งคลิก (ถ้าคุณต้องการให้ target เคลื่อนไหว)
            target.transform.position = new Vector2(targetPosition.x, targetPosition.y);

            // คำนวณความเร็วสำหรับการยิง
            Vector2 projectileVelocity = CalculateProjectileVelocity(shootPoint.position, targetPosition, 1f);

            // สร้างกระสุนใหม่
            Rigidbody2D firedBullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);

            // ใส่ความเร็วให้กระสุน
            firedBullet.linearVelocity = projectileVelocity;
        }
    }

    Vector2 CalculateProjectileVelocity(Vector2 origin, Vector2 target, float time)
    {
        Vector2 distance = target - origin;

        float velocityX = distance.x / time;
        float velocityY = distance.y / time + 0.5f * Mathf.Abs(Physics2D.gravity.y) * time;

        return new Vector2(velocityX, velocityY);
    }
}