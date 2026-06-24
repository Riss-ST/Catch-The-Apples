using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // spawner apel
    [SerializeField] private GameObject[] itemPrefabs;
    [SerializeField] private float spawnInterval = 1.5f;
    [SerializeField] private float spawnRangeX = 7f;
    [SerializeField] private float spawnHeight = 6f;

    // poin & waktu
    [SerializeField] private float gameTime = 10f;
    private int score = 0;
    private bool isGameOver = false;

    void Awake(){

        if (instance == null) instance = this;
    }
    void Start()
    {
        InvokeRepeating("SpawnRandom", 0.5f, spawnInterval);
    }
    void Update(){
        if (isGameOver) return;

        gameTime -= Time.deltaTime;

        if(gameTime <= 0){
            EndGame();
        }
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
        score++;
        Debug.Log("Skor = " + score);
    }

    public void AddTime(float amount)
    {
        if(isGameOver) return;
        gameTime += amount;
        Debug.Log("Waktu bertambah = " + amount);
    }

    public void ReduceTime(float amount)
    {
        if(isGameOver) return;
        gameTime -= amount;
        Debug.Log("Waktu berkurang = " + amount);
    }

    void EndGame()
    {
        isGameOver = true;
        UIManager.instance.panelGameOver.SetActive(true);
        CancelInvoke("SpawnRandom");
        Debug.Log("GAME OVER! skor akhir" + score);

        Time.timeScale = 0f;

    }
}
