using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePause = false;
    public GameObject PauseMenuUI;
    public Button yourButton;
    private void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePause)
            {
                
                ResumeF();
            }
            else
            {
                
                PauseF();
            }
        }

    }
    void TaskOnClick()
    {
        if (GamePause)
        {
            ResumeF();
        }
        else
        {
            PauseF();
        }
    }
    public void ResumeF()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePause = false;
        FindObjectOfType<AudioManager>().Play("Car");
    }
    void PauseF()
    {
        FindObjectOfType<AudioManager>().StopPlaying("Car");
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePause = true;
    }
    public void MainMenu()
    {

        Time.timeScale = 1f;
        SceneManager.LoadScene("StartMenu");
    }
    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Gameplay");
    }
}
