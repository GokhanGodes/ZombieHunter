using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour {

    public GameObject GameOverMenu;
    public Text ScoreText;
    private AdManager Admob;
	void Start () {
        Admob = GameObject.Find("AdmobManager").GetComponent<AdManager>();
        GameOverMenu.SetActive(false);
    }
	
	void Update () {
        //Admob.ShowVideo();
        ScoreText.text = "SCORE\n" + Statik.Skor;
        if(Statik.GOMenu)
        {
            GameOverMenu.SetActive(true);

        }
        else
        {
            GameOverMenu.SetActive(false);
        }
		
	}
    public void OnReplay()
    {
        SceneManager.LoadSceneAsync("SampleScene");
    }
    public void OnMenu()
    {
        SceneManager.LoadSceneAsync("MenuScene");
    }
    public void OnExit()
    {
        Application.Quit();
    }
}   