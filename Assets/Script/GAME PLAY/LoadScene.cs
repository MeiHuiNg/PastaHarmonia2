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

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level 2");
    }
    public void LoadLevel3()
    {
        SceneManager.LoadScene("Level 3");
    }

    public void LoadLevel4()
    {
        SceneManager.LoadScene("Level 4");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Page");
    }

    public void LoadHowToPlay()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void LoadFreeMode()
    {
        SceneManager.LoadScene("Free Mode");
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    public void Level4Ending()
    {
        Invoke("LoadMainMenu",3f);
    }
}
