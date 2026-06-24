using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu_Manager : MonoBehaviour
{

    public GameObject buttonStart;  
    public GameObject buttonQuit;
    // Start is called before the first frame update
    public void ButtonStart(){

        Time.timeScale = 1f;
        SceneManager.LoadScene(1);  
        
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
