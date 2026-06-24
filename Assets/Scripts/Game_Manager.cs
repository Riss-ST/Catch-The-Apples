using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{
    
    public static Game_Manager instance;

    // spawner apel
    [SerializeField] private GameObject[] itemPrefabs;
    [SerializeField] private float spawnInterval = 1.5f;
    [SerializeField] private float spawnRangeX = 7f;
    [SerializeField] private float spawnHeight = 6f;

    // poin & waktu

    private int score = 0;
    private int currentScore;

    public float setHealth = 5f;
    public float currentHealth;
    private float refhealth;
    private bool isGameOver = false;

    void Awake(){

        if (instance == null) instance = this;
    }
    void Start()
    {
        InvokeRepeating("SpawnRandom", 0.5f, spawnInterval);

        currentHealth = setHealth;

        UI_Manager.instance.UpdateScoreUI(score);
        UI_Manager.instance.UpdateHealthUI(currentHealth / setHealth); 
    }
    void Update()
    {
        
    }

    void SpawnRandom()
    {
        int randomIndex = Random.Range(0, itemPrefabs.Length);

        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPosition = new Vector3(randomX, spawnHeight, 0);

        Instantiate(itemPrefabs[randomIndex], spawnPosition, Quaternion.identity);
    }

    
    public void AddScore()
    {
        score += 1;
        Debug.Log("Skor = " + score.ToString());

        UI_Manager.instance.UpdateScoreUI(score);
    }
    public void AddHealth()
    {
        if(currentHealth < 5f)
        {
            currentHealth += 1f;
            refhealth = currentHealth/setHealth;
            UI_Manager.instance.UpdateHealthUI(refhealth);
            
        }
        Debug.Log("Health = " + currentHealth.ToString());
    }
    public void ReduceHealth()
    {
        currentHealth -= 1f;
        refhealth = currentHealth/setHealth;
        UI_Manager.instance.UpdateHealthUI(refhealth);
        Debug.Log("Health = " + currentHealth.ToString());

        if(currentHealth <= 0)
        {
            EndGame();
        }
        
    }


    void EndGame()
    {
        isGameOver = true;
        UI_Manager.instance.panelGameOver.SetActive(true);
        CancelInvoke("SpawnRandom");
        Debug.Log("GAME OVER! skor akhir" + score);
        UI_Manager.instance.panelGameOver.SetActive(true);
        UI_Manager.instance.DisplayGameOverUI(score); 

        Time.timeScale = 0f;

    }
}
