using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    public Text LastScore, HighScore;
	void Start () {

	}
	
	void Update () {
        LastScore.text = "Last Score\n" + PlayerPrefs.GetInt("LastScore").ToString();
        HighScore.text = "High Score\n" + PlayerPrefs.GetInt("HighScore").ToString();
	}
    public void OnPlay()
    {
        SceneManager.LoadScene("LoadingScene");
    }
    public void OnStore()
    {
        SceneManager.LoadScene("StoreScene");
    }
    public void OnExit()
    {
        Application.Quit();
    }
    public void OnCharacter()
    {
        SceneManager.LoadScene("CharacterScene");
    }
}
