using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool Paused = false;
    public GameObject pauseMenuUi;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (Paused){
                Resume();
            }else{
                Pause();
            }
        }
    }
    public void Resume(){
        pauseMenuUi.SetActive(false);
        Time.timeScale=1f;
        Paused=false;
    }
    public void LoadMenu(){
        Time.timeScale=1f;
        Paused=false;
        SceneManager.LoadScene("Menus");
    }
    public void QuitGame(){
        Application.Quit();
    }
    void Pause(){
        pauseMenuUi.SetActive(true);
        Time.timeScale=0f;
        Paused=true;
    }
}
