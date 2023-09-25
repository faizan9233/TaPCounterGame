using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int tapCount;
    public GameplayUI gameplayUI;
    public float Timer;
    public float defaultTimerValue;
    public bool timerHasEnded = false;
    int targetCount;
    public bool hasWon;
    public static int highScore;
    public float countDownTimer;
    public bool countDownHasEnded;
    int baselevelMultiplyer = 10;
     int levelNum = 1;
    

    // Start is called before the first frame update
    void Start()
    {
        countDownTimer = 3;
        Timer = defaultTimerValue;
        GetHighScore();
       



        levelNum = PlayerPrefs.GetInt("levelNum",1);
        targetCount = getTapTargetCount(levelNum);
       

        

        Debug.Log("Target count is: " + targetCount);
    }

    // Update is called once per frame
    void Update()
    {

        if (countDownHasEnded == false)
        {
            countDownTimer = countDownTimer - Time.deltaTime;
            if (countDownTimer <= 0)
            {
                countDownHasEnded = true;
                gameplayUI.disableCountDownText();
            }
        }

        if (countDownHasEnded ==true &&  timerHasEnded == false)
        {
            gameplayUI.Disablereadytxt();
            Timer = Timer - Time.deltaTime;

            if (Timer <= 0)
            {
                timerHasEnded = true;
                Timer = 0;

                if (tapCount < targetCount)
                {
                    hasWon = false;
                }
                else
                {
                    hasWon = true;

                }

                if (tapCount > highScore)
                    highScore = tapCount;

                gameplayUI.ShowHighScore();
                gameplayUI.ShowwinOrgameoverPanel();
                SaveHighScore();
                
            }
            
            if (gameplayUI.isPaused==false && Input.GetMouseButtonDown(0))
            {
                gameplayUI.updateTapCountText();
                
                tapCount++;
                gameplayUI.TapSound();
            }
        }
    }

    public void SaveHighScore()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
    }
    public void GetHighScore()
    {
       highScore =  PlayerPrefs.GetInt("HighScore");
    }

    int getTapTargetCount(int _levelnum)
    {
        int tempvalue=0;
        tempvalue = baselevelMultiplyer * _levelnum;
         return tempvalue;
    }

    public void increaselevel()
    {
        levelNum++;
       
        PlayerPrefs.SetInt("levelNum", levelNum);
    }

    public int getlevelNum()
    {
        return levelNum;
    }

  
    
}
