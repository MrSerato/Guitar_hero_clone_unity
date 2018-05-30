using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    int multiplier = 1;
    int streak = 0;

	// Use this for initialization
	void Start ()
    {
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("Streak", 0);
        PlayerPrefs.SetInt("High Streak", 0);
        PlayerPrefs.SetInt("Multiplier", 1);
        PlayerPrefs.SetInt ("PerformanceMeter", 25);
        PlayerPrefs.SetInt("Notes Hit", 0);
        PlayerPrefs.SetInt("Start", 0);
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        resetStreak();
        Destroy(col.gameObject); //disable in create
    }


    public void addStreak()
    {
		if(PlayerPrefs.GetInt("PerformanceMeter")+1<50)
			PlayerPrefs.SetInt ("PerformanceMeter", PlayerPrefs.GetInt ("PerformanceMeter") + 1);
        streak++;
        //Debug.Log("Added to streak! Current streak is: " + streak);
        if (streak >= 12)
            multiplier = 4;
        else if (streak >= 8)
            multiplier = 3;
        else if (streak >= 4)
            multiplier = 2;
        else
            multiplier = 1;
        //Debug.Log("Performance Meter Score: " + PlayerPrefs.GetInt("Performance Meter"));

        if(streak > PlayerPrefs.GetInt("Highest Streak"))
        {
            PlayerPrefs.SetInt("Highest Streak", streak);
        }

        PlayerPrefs.SetInt("Notes Hit", PlayerPrefs.GetInt("Notes Hit") + 1);

        updateGUI();
    }

    public void resetStreak()
    {
        //Debug.Log("Streak was reset");
        PlayerPrefs.SetInt("PerformanceMeter", PlayerPrefs.GetInt("PerformanceMeter") - 2);
        //Debug.Log("Performance Meter Score: " + PlayerPrefs.GetInt("Performance Meter"));
        if (PlayerPrefs.GetInt("PerformanceMeter") - 6 < 0)
            Lose(); //disable in create
        streak = 0;
        multiplier = 1;
        updateGUI();
    }

    void updateGUI()
    {
        PlayerPrefs.SetInt("Streak", streak);
        PlayerPrefs.SetInt("Mult", multiplier);
    }

    public int getScore()
    {
        return 100 * multiplier;
    }

    public void Lose()
    {
        PlayerPrefs.SetInt("Start", 0);
        SceneManager.LoadScene("LoseScreen");
    }

    public void Win()
    {
        PlayerPrefs.SetInt("Start", 0);
        if (PlayerPrefs.GetInt("High Score") < PlayerPrefs.GetInt("Score"))
            PlayerPrefs.SetInt("High Score", PlayerPrefs.GetInt("Score"));
        SceneManager.LoadScene("VictoryScreen");
    }
    
}
