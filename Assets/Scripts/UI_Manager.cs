using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    
    public static UI_Manager instance;
    public Slider healthSlider;
    public GameObject panelHome;
    public GameObject panelGamePlay;
    public GameObject panelGamePaused;
    public GameObject panelGameOver;

    public GameObject buttonStart;
    public GameObject buttonPause;
  
    public GameObject buttonQuit;

    public Image healthBarFG;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalScoreText; 
    public TextMeshProUGUI highScoreText;

    // Start is called before the first frame update

    void Start()
    {
        AllPanelOff();
        panelGamePlay.SetActive(true);
    }
     void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void UpdateHealthUI(float refhealth)
    {
        healthBarFG.fillAmount = refhealth;
            
    }

    public void DisplayGameOverUI(int finalScore)
{
    finalScoreText.text = "SCORE : " + finalScore.ToString();

    int currentHighScore = PlayerPrefs.GetInt("HighScore", 0);

    if (finalScore > currentHighScore)
    {
        currentHighScore = finalScore;
        PlayerPrefs.SetInt("HighScore", currentHighScore); 
        PlayerPrefs.Save();
    }


        highScoreText.text = "HIGHEST SCORE : " + currentHighScore.ToString();
}

    void AllPanelOff(){
        panelGamePlay.SetActive(false);
        panelGamePaused.SetActive(false);
        panelGameOver.SetActive(false);
    }
    // Update is called once per frame

    public void ButtonRestart(){
        
        SceneManager.LoadScene(1);
        AllPanelOff();
        panelGamePlay.SetActive(true);
        Time.timeScale = 1f;

    }
    public void ButtonResume(){
        
        AllPanelOff();
        panelGamePlay.SetActive(true);
        Time.timeScale = 1f;

    }

    public void ButtonPause(){

        AllPanelOff();

        panelGamePaused.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ButtonHome(){

        AllPanelOff();

        panelHome.SetActive(true);

    }
    
    public void UpdateScoreUI(int currentScore)
    {
    if (scoreText != null)
    {
        scoreText.text = "SCORE: " + currentScore.ToString();
    }
    }

   public void ButtonQuit(){
    #if UNITY_EDITOR
        
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        // Jika game sudah di-build jadi aplikasi (.exe / .apk)
        Application.Quit();
        
    #endif 

    }
}
