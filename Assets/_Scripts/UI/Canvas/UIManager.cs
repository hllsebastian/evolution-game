using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject panelPause;
    public static bool isPaused = false;
    public Slider musicVolSlider, sfxVolSlider;

    
    public GameObject muteButton;
    public GameObject unMuteButton;
    private bool isMuted = false;


    private void Awake()
    {
        instance = this;
    }
    
    void Start()
    {
        musicVolSlider.value = AudioManager.instance.GetMusicLevel();
        sfxVolSlider.value = AudioManager.instance.GetSFXLevel();

        UpdateButtonState();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();
        }
    }

    public void PauseUnpause()
    {
        if (isPaused)
        {
            isPaused = false;
            panelPause.SetActive(false);
            Time.timeScale = 1f;

            Cursor.visible = false; 
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            isPaused = true;
            panelPause.SetActive(true);
            Time.timeScale = 0f;

            Cursor.visible = true; 
            Cursor.lockState = CursorLockMode.None;
        }
    }

   
    public void SetMusicLevel()
    {
        AudioManager.instance.SetMusicLevel();
    }

    public void SetSFXLevel()
    {
        AudioManager.instance.SetSFXLevel();
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManagerObject.Instance.ReloadScene();
    }

    public void ChangeScene()
    {
        Time.timeScale = 1f;
        SceneManagerObject.Instance.LoadScene(0);
    }

   
    public void ToggleMute()
    {
        isMuted = !isMuted;

        
        AudioListener.volume = isMuted ? 0f : 1f;

       
        UpdateButtonState();
    }

    
    private void UpdateButtonState()
    {
        muteButton.SetActive(!isMuted);
        unMuteButton.SetActive(isMuted);
        
    }
}
