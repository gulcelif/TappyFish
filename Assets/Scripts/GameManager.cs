using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static Vector2 bottomleft;
    public static bool gameOver;
    public GameObject gameOverPanel;
    private void Awake()
    {

        bottomleft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
    }
    public void RestartBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void Start()
    {
        gameOver = false;
    }
    public void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive(true); 
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
