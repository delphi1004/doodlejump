using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Vector3 spawnPosition;
    private int score = 0;
    private int totalPlatform = 0;
    private AudioSource audio;
    public int platformCount = 5;
    public GameObject player;
    public GameObject platformPrefab;
    public GameObject gameOver;
    public GameObject playButton;
    public Text labelScore;

    private void ShowScore()
    {
        labelScore.text = "SCORE "+score.ToString();
    }

    void Awake()
    {
        GameOver();
        audio = GetComponent<AudioSource>();
        audio.Stop();
    }

    void Start()
    {
        spawnPosition = new Vector3();
        spawnPosition.y = -5f;
        CreatePlatform();
    }

    public void CreatePlatform()
    {
        if(totalPlatform < platformCount){
            Debug.Log("CreatePlatform");
            for(int i=0;i<platformCount;i++)
            {
                spawnPosition.y += Random.Range(1f,3f);
                spawnPosition.x = Random.Range(-1.8f,1.8f);
                spawnPosition.z = 1;
                Instantiate(platformPrefab,spawnPosition,Quaternion.identity); 
            }

            totalPlatform += platformCount;
        }
    }

    public void Play()
    {
        score = 0;
        player.SetActive(true);
        gameOver.SetActive(false);
        playButton.SetActive(false);
        CreatePlatform();
    }

    public void GameOver()
    {
        score = 0;
        player.SetActive(false);
        gameOver.SetActive(true);
        playButton.SetActive(true);
        ShowScore();

        Debug.Log("Game over");
    }

    public void AddScore()
    {
        score++;
        ShowScore();
        audio.Play();
    }

    public void DescreasePlatform()
    {
        totalPlatform--;
       // Debug.Log(totalPlatform);
    }

    void Update()
    {
        
    }
}
