using System.Drawing;
using UnityEngine;

public class EndGameZone : MonoBehaviour
{
    private UIGameManager gameManager;
    public GameObject JonyEndGame;
    public GameObject CloseJony;


    private void OnCollisionEnter2D(Collision2D player)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game End");
            JonyEndGame.SetActive(true);
            CloseJony.SetActive(false);
        }
    }
}
