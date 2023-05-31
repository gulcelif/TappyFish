using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Vector2 bottomleft;
    public static bool gameOver;

    private void Awake()
    {

        bottomleft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
    }
    void Start()
    {
        gameOver = false;
    }
    public void GameOver()
    {
        gameOver = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
