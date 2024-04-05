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
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Método para cambiar el estado del sonido
    public void ToggleMute()
    {
        isMuted = !isMuted;

        // Mutea o desmutea el audio de la escena
        AudioListener.volume = isMuted ? 0f : 1f;

        // Actualiza el estado de los botones
        UpdateButtonState();
    }

    
    private void UpdateButtonState()
    {
        muteButton.SetActive(!isMuted);
        unMuteButton.SetActive(isMuted);
        
    }
}
