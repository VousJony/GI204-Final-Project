using UnityEngine;
using UnityEngine.EventSystems;


public class ScoreCount : MonoBehaviour
{
    

    public int point;
    private UIGameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<UIGameManager>();
    }
    

    private void OnCollisionEnter(Collision Player)
    {
        if (Player.gameObject.CompareTag("Player"))
        {
            gameManager.UpdateScore(point);
            Destroy(gameObject);
            Debug.Log("+1");
            
        }
    }
}