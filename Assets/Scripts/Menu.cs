using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void PlayMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
        Obstacle.isCollided = false;
    }
    public void RestartMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        Obstacle.isCollided = false;
        
    }
    public void ResumeMenu()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
    public void PauseMenu()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);

    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
        Obstacle.isCollided = false;
      
    }
    public void Quit()
    {
        Application.Quit();
    }
 
}
