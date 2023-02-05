using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public bool Over = false;
    public GameObject gameOverUi;
    public GameObject globalJuego;
    private Scene currentScene;
    private string SceneName;

    private void Start() {
        currentScene = SceneManager.GetActiveScene();
        SceneName = currentScene.name;
    }

    // Update is called once per frame
    void Update()
    {
        if (Over) {
            GameOver();
        }
    }
    public void Restart(){
        Time.timeScale=1f;
        Over=false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void LoadMainMenu(){
        Time.timeScale=1f;
        Over=false;
        SceneManager.LoadScene(0);
    }
    public void RageQuit(){
        Application.Quit();
    }
    void GameOver(){
        gameOverUi.SetActive(true);
        Time.timeScale=0f;
        Over=true;
    }
}