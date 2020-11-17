using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Scenes : MonoBehaviour
{
    public CanvasGroup UICanvas;
    public GameObject PurchaseCanvas;

    private void Start()
    {
        PurchaseCanvas.SetActive(false);
    }

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
        ImageOrder.imageSet = 1;
    }

    public void PurchaseSet()
    {
        UICanvas.alpha = .3f;
        UICanvas.interactable = false;
        PurchaseCanvas.SetActive(true);
    }

    public void No()
    {
        UICanvas.alpha = 1f;
        UICanvas.interactable = true;
        PurchaseCanvas.SetActive(false);
    }

   public void Exit()
    {
        Application.Quit();

    }
}
