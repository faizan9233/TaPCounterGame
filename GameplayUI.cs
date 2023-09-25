using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayUI : MonoBehaviour
{
    public GameObject tapCountText;
    public GameManager gameManager;
    public GameObject timerText;
    public GameObject winPanel;
    public GameObject GameOverPanel;
    public Text highScoreText;
    public GameObject PausePanel;
    public bool isPaused;
    public GameObject countDownText;
    public GameObject Readytxt;
    public AudioClip btnaudio;
    public AudioSource gameplayAudio;
    public AudioSource WinMusic;
    public AudioClip tapSound;
   public AudioSource GameOverSound;
    
    
  //  public AudioClip[] tapSounds;    //For Random Sounds on Every TAp
   
    // Start is called before the first frame update
    void Start()
    {
        highScoreText.text = "";
        gameplayAudio.Play();
    }
    
   public void updateTapCountText()
    {
        tapCountText.GetComponent<Text>().text = gameManager.tapCount.ToString();
    }

    public void Update()
    {
        timerText.GetComponent<Text>().text = "Timer:" + gameManager.Timer.ToString("#");
        if (gameManager.countDownHasEnded == false)
        {
            countDownText.GetComponent<Text>().text = gameManager.countDownTimer.ToString("#");
        }
    }

    public void disableCountDownText()
    {
        countDownText.gameObject.SetActive(false);
    }
    public void ShowwinOrgameoverPanel()
    {
        if (gameManager.hasWon == true)
        {
            winPanelMusic();
            gameplayAudio.Pause();
            winPanel.SetActive(true);

           
        }
        else
        {
            gameovermusic();
            gameplayAudio.Pause();
            GameOverPanel.SetActive(true);
        }

    }

    public void MainMenuBtnClicked()
    {
        BtnSounds();
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void Replaybtnclicked()
    {
        BtnSounds();
        SceneManager.LoadScene(1);
    }

   public void ShowHighScore()
    {
        highScoreText.text ="HighScore: " +GameManager.highScore.ToString();
    }

    public void pause()
    {
        
        isPaused = true;
        PausePanel.SetActive(true);
        Time.timeScale = 0;
        gameplayAudio.Pause();
       
    }

    public void resumebtnclicked()
    {

        BtnSounds();
        isPaused = false;
        PausePanel.SetActive(false);
        Time.timeScale = 1;
        
    }

    public void Disablereadytxt()
    {
        Readytxt.SetActive(false);
    }

    public void BtnSounds()
    {
        gameplayAudio.PlayOneShot(btnaudio);
    }

    public void winPanelMusic()
    {
        WinMusic.Play();
    }
    public void TapSound()
    {
        //int randomIndex = Random.Range(0, tapSounds.Length);                      //For Random Sounds on Every TAp
        // AudioClip _clip = tapSounds[randomIndex];

        gameplayAudio.PlayOneShot(tapSound);
    }
    public void gameovermusic()
    {
        GameOverSound.Play();
    }

    public void nextLevel()
    {
        gameManager.increaselevel();
        Debug.Log("going to nxt lvl" + gameManager.getlevelNum());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

   
}
