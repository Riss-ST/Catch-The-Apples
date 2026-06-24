using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject panelHome;
    public GameObject panelGamePlay;
    public GameObject panelGamePaused;
    public GameObject panelGameOver;

    public GameObject buttonStart;
    public GameObject buttonPause;
    public GameObject buttonHome;
    public GameObject buttonQuit;
    // Start is called before the first frame update
    void Start()
    {
        panelHome.SetActive(true);
        panelGamePlay.SetActive(false);
        panelGamePaused.SetActive(false);
        panelGameOver.SetActive(false);

        Time.timeScale = 0f;

    }
     void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void AllPanelOff(){

        panelHome.SetActive(false);
        panelGamePlay.SetActive(false);
        panelGamePaused.SetActive(false);
        panelGameOver.SetActive(false);
    }
    // Update is called once per frame
    public void ButtonStart(){

        AllPanelOff();

        panelGamePlay.SetActive(true);
        Time.timeScale = 1f;
        
    }
    public void ButtonRestart(){
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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

   public void ButtonQuit(){
    #if UNITY_EDITOR
        
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        // Jika game sudah di-build jadi aplikasi (.exe / .apk)
        Application.Quit();
        
    #endif 

    }
}
