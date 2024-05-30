using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public PLayerController playerController;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Resume()
    {
        gameObject.GetComponent<PLayerController>().enabled = true;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        gameIsPaused = false;
    }
    void Pause()
    {
        gameObject.GetComponent<PLayerController>().enabled = false;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
    public void togglePauseState()
    {
        gameObject.GetComponent<PLayerController>().enabled = true;
        gameIsPaused = false;
        Time.timeScale = 1.0f;
        pauseMenuUI.SetActive(false);
    }
}
