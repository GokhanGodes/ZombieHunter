using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour {

    public int LastScore, NextScore, HighScore;

	void Start () {
        if (!PlayerPrefs.HasKey("LastScore") && !PlayerPrefs.HasKey("HighScore"))
        {
            LastScore = 0;
            NextScore = 0;
            HighScore = 0;
        }
		else
        {
            LastScore = PlayerPrefs.GetInt("LastScore");
            HighScore = PlayerPrefs.GetInt("HighScore");
        }
	}
	
	void Update () {

        if(Statik.GOMenu || Statik.PMenu)
        {
            LastScore = Statik.Skor;
            PlayerPrefs.SetInt("LastScore", LastScore);
            NextScore = Statik.Skor;
            if(NextScore>HighScore)
            {
                HighScore = NextScore;
                PlayerPrefs.SetInt("HighScore", HighScore);
            }
            NextScore = 0;
        }
		
	}
}
