using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowtoPlay : MonoBehaviour
{
    // Start is called before the first frame update
    public void BacktoMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);  // go back to original main menu
    }
}
