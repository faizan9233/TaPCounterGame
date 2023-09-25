using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject credits;
    public GameObject howToPlay;
    public GameObject settings;
    public AudioSource gameAudio;
    public AudioClip btnAudio;
 
    
    public GameObject FadePanel;
 //   public GameObject HTPPanel;
 //   public GameObject CreditsPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        fadeIn();
        mainMenu.SetActive(true);
        credits.SetActive(false);
        howToPlay.SetActive(false);
        settings.SetActive(false);
       
    }
    
    public void settingbtnClicked()
    {
        btnSound();
        
        mainMenu.SetActive(false);
        settings.SetActive(true);
       
        
      //  SettingAnimator.SetTrigger("Slide-In");
       
    }
    public void creditsbtnclicked()
    {
        mainMenu.SetActive(false);
        credits.SetActive(true);
        btnSound();
      //  creditsFadein();
    }

    public void howtoplaybtnClicked()
    {
        mainMenu.SetActive(false);
        howToPlay.SetActive(true);
        btnSound();
       // HTPfadein();
    }

    public void backbtnClicked()
    {
        btnSound();
        mainMenu.SetActive(true);
        credits.SetActive(false);
        howToPlay.SetActive(false);
        settings.SetActive(false);
    }
        //Invoke("DisableSettingdbtn", 1);

      //  StartCoroutine(DisableSettingdbtn());
     //   SettingAnimator.SetTrigger("Slide-Out");
        
   // }

   // public IEnumerator DisableSettingdbtn()
   // {
    //    yield return new WaitForSeconds(1);
      //  settings.SetActive(false); 
       // settingsbtn.SetActive(true);
    
    public void playbtnClicked()
    {
        fadeOut();
        StartCoroutine(DelayToPlay());

    }
   IEnumerator DelayToPlay()
    {                                                    // For Delay Execution of Code.......//
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }


    public void Audiobtn()
    {
        gameAudio.Play();
    }
    public void btnSound()
    {
        gameAudio.PlayOneShot(btnAudio);
    }

    public void fadeIn()
    {
        FadePanel.GetComponent<Animator>().SetTrigger("Fade-in");
    }

    public void fadeOut()
    {
        FadePanel.GetComponent<Animator>().SetTrigger("Fade-out");
    }

   /* public void HTPfadein()
    {
        HTPPanel.GetComponent<Animator>().SetTrigger("Fade-in");
    }
   
    public void creditsFadein()
    {
        CreditsPanel.GetComponent<Animator>().SetTrigger("Fade-in");
    }*/
   
    public void PauseMusic()
    {
        gameAudio.Pause();
    }
}
