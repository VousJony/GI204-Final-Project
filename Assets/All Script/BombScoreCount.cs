using UnityEngine;
using UnityEngine.EventSystems;


public class BombScoreCount : MonoBehaviour
{
    

    public int point;
    private int DeHealth = -1;
    private UIGameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<UIGameManager>();
    }
    

    private void OnCollisionEnter2D(Collision2D Player)
    {
        if (Player.gameObject.CompareTag("Player"))
        {
            gameManager.UpdateScore(point);
            gameManager.DeleteScore(DeHealth);
            Destroy(gameObject);
            Debug.Log("Boom!");
            
            
        }
    }
}