using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Scenes : MonoBehaviour
{
    
    public void StartingScene()
    {
        SceneManager.LoadScene("StartingScene");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("AlbumTestr");
    }

    public void ImageSet1()
    {
        SceneManager.LoadScene("ImageSet1");
    }

    public void ImageSet2()
    {
        SceneManager.LoadScene("ImageSet2");
    }

    public void Exit()
    {
        Application.Quit();

    }
}
