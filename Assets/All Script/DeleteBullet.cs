using System.Drawing;
using UnityEngine;

public class DeleteBullet : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D Hit)
    {
        if (Hit.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
            Destroy(Hit.gameObject);

        }
        if (Hit.gameObject.CompareTag("Bullet"))
        {
            //Good
        }

        if (Hit.gameObject.CompareTag("Player"))
        {
            //Good
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
