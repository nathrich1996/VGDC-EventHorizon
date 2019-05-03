using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DeathMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public bool deathScreenActive = false;
    MusicControl mControl;
    void Start()
    {
        gameObject.SetActive(false);
        mControl = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MusicControl>();
    }

    // Update is called once per frame
    public void ToggleDeathMenu()
    {
        mControl.DeathAudio();
        deathScreenActive = true;
        gameObject.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void QuitToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
  
}
