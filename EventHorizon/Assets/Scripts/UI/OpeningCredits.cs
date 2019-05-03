using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OpeningCredits : MonoBehaviour
{
    // Start is called before the first frame update
    public MainMenu mm;
   public Image ocImage;
    IEnumerator Start()
    {
        ocImage.GetComponent<Image>();
        ocImage.canvasRenderer.SetAlpha(0f);
        FadeIn();
        yield return new WaitForSeconds(2.5f);
        FadeOut();
        yield return new WaitForSeconds(2.5f);
        mm.ToggleMainMenu();
    }

    public void FadeIn()
    {
        ocImage.CrossFadeAlpha(1.0f, 1.5f, false);
    }
    public void FadeOut()
    {
        ocImage.CrossFadeAlpha(0f, 2.5f, false);
    }
}