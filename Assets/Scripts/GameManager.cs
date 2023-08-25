using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //targets\\
    public List<GameObject> targets;
    public float spawnRate = 1.5f;

    //UI\\
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button resetGameButton;
    public GameObject tittleScreen;

    //game\\
    public bool gameOver = false;
    private int score = 0;
    
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while(!gameOver)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
       
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverText.gameObject.SetActive(true);
        resetGameButton.gameObject.SetActive(true);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void StartGame(float difficulty)
    {
        spawnRate /= difficulty;

        gameOver = false;
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);

        tittleScreen.gameObject.SetActive(false);
    }

}


