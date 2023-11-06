using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    public static bool IsPaused;
    private bool OnSettings;

    public GameObject PausePanel;
    public GameObject SettingsPanel;

    public AudioSettings audioSettings;

    private void Awake()
    {
        IsPaused = false;
        OnSettings = false;
        PausePanel.SetActive(false);
        SettingsPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(IsPaused)
            {
                Resume();
            }
            else if(OnSettings)
            {
                audioSettings.SaveAudioSettings();
                Pause();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        IsPaused = false;
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Settings()
    {
        IsPaused = false;
        PausePanel.SetActive(false);
        OnSettings = true;
        SettingsPanel.SetActive(true);
    }

    public void Pause()
    {
        IsPaused = true;
        PausePanel.SetActive(true);
        OnSettings = false;
        SettingsPanel.SetActive(false);
        Time.timeScale = 0f;
    }
}
