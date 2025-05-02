using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;
using Unity.VisualScripting;

public class UIGameManager : MonoBehaviour
{
    public List<GameObject> targets;

    [Header("UI Elements")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreTextSummary;
    public TextMeshProUGUI scoreSummaryDefeat;
    public TextMeshProUGUI HealthText;


    public GameObject titleScreen;
    public GameObject gameOverScreen;
    public GameObject scoreScreen;
    public GameObject creditScreen;
    public GameObject DefeatScreen;
    public GameObject hp1;
    public GameObject hp2;
    public GameObject hp3;
    public Button ExitButton;
    public Button playButton;
    public Button restartButton;
    public Button restartButtonOnDefeat;
    public Button creditButton;

    private int Health;
    private int score;

  

    void Awake()
    {
        Health = 3;
        playButton.onClick.AddListener(() => { PlayGame(); });
        restartButton.onClick.AddListener(() => { Restart(); });
        creditButton.onClick.AddListener(() => { CreditShow(); });
        ExitButton.onClick.AddListener(() => { Exit(); });
        restartButtonOnDefeat.onClick.AddListener(() => { Restart(); });
    }
    void Start()
    {
        gameOverScreen.SetActive(false);
        scoreScreen.SetActive(false);
        titleScreen.SetActive(true);
        

    }

    private void FixedUpdate()
    {
        if (Health == 0)
        {
            DefeatUI();
        }
        if (Health == 1)
        {
            hp1.SetActive(true);
            hp2.SetActive(false);
            hp3.SetActive(false);
        }
        if (Health == 2)
        {
            hp1.SetActive(true);
            hp2.SetActive(true);
            hp3.SetActive(false);
        }
        if (Health == 3)
        {
            hp1.SetActive(true);
            hp2.SetActive(true);
            hp3.SetActive(true);
        }
    }

    void StartGame(bool difficulty)
    {
        
        titleScreen.SetActive(false);
        
    }


    public void UpdateScore(int score)
    {
        this.score += score;
        scoreText.text = this.score.ToString();
        scoreTextSummary.text = this.score.ToString();
        scoreSummaryDefeat.text = this.score.ToString();
    }

    public void DeleteScore(int Health)
    {
        this.Health += Health;
        HealthText.text = this.Health.ToString();
        

    }
    public void GameEnd()
    {
        Debug.Log("Jony End");
        gameOverScreen.SetActive(true);
        scoreScreen.SetActive(false);
    }

    public void DefeatUI()
    {
        Debug.Log("Jony Defeat");
        scoreScreen.SetActive(false);
        DefeatScreen.SetActive(true);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void Restart()
    {
        /*SceneManager.LoadScene("Main");*/
        var activeScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(activeScene.name);
    }

    public void PlayGame()
    {
        titleScreen.SetActive(false);
        scoreScreen.SetActive(true);
    }

    public void CreditShow()
    {
        scoreScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        creditScreen.SetActive(true);
    }

   
   
}


