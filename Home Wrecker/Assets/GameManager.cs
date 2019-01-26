using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject menu;
    public GameObject game;
    public GameObject instructions;
    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(true);
        game.SetActive(false);
        instructions.SetActive(false);
        gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        menu.SetActive(false);
        game.SetActive(true);
        instructions.SetActive(false);
        gameOver.SetActive(false);
    }

    public void Instructions()
    {
        menu.SetActive(false);
        game.SetActive(false);
        instructions.SetActive(true);
        gameOver.SetActive(false);
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
    }
}
