using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScene : MonoBehaviour
{
    private bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !isPaused)
        {
            isPaused = !isPaused;
            SceneManager.LoadScene("PauseScene",LoadSceneMode.Additive);
        }
        else if (Input.GetKeyDown(KeyCode.P) && isPaused)
        {
            isPaused = !isPaused;
            SceneManager.UnloadScene("PauseScene");
        }
    }
}
