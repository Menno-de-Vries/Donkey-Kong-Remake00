using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenemanagement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevelTest()
    {
        SceneManager.LoadScene("Main Scene Storm");
    }

    public void LoadLevelMenu()
    {
        SceneManager.LoadScene("Start Screen");
    }

    public void LoadLevelTrue()
    {
        SceneManager.LoadScene("Main Scene Menno");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ZA_WARUDO()
    {
        Time.timeScale = 1f;
    }
}
