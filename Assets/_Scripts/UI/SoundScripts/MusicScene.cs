using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicScene : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlayMusic(SceneManager.GetActiveScene().buildIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
