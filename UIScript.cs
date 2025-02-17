using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{

    public GameObject Restart, Quit, StartPicture, start;
    bool UIActive = false, pressToStart = false;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (UIActive)
            {
                Restart.SetActive(false);
                Quit.SetActive(false);
                UIActive = false;
            }
            else
            {
                Restart.SetActive(true);
                Quit.SetActive(true);
                UIActive = true;
            }
        }
    }
    public void StartGame()
    {
        StartPicture.SetActive(false);
        start.SetActive(false);
    }
    public void Replay01()
    {
        SceneManager.LoadScene("Stage");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
