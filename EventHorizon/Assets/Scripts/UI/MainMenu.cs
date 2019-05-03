using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public Image mmImage;
    private void Start()
    {
        gameObject.SetActive(false);
    }
    public void ToggleMainMenu()
    {
        mmImage.canvasRenderer.SetAlpha(0f);
        gameObject.SetActive(true);
        FadeIn();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1); //Play game
    }
    public void QuitGame()
    {
        Application.Quit(); //Quit Game
        Debug.Log("Quit Game");
    }
    public void PlayCredits()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2); //PlayCredits
    }
    void FadeIn()
    {
        mmImage.CrossFadeAlpha(1.0f, 1.5f, false);
    }
}
