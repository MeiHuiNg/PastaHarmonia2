using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    LoadScene instance;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;

        //DontDestroyOnLoad(this);
    }

    public void LoadMainGame()
    {
        SceneManager.LoadScene("MainGamePlay");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("StartPage");
    }

    public void LoadHowToPlay()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
