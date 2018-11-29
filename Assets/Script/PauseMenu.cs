using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject Pausemenu;
    public AudioSource GameSource;
    public AudioClip GameSound;
	void Start () {
        Pausemenu.SetActive(false);
        Statik.PMenu = false;
        if (PlayerPrefs.GetString("Sounds") == "On")
        {
            GameSource.PlayOneShot(GameSound);
        }

    }
	
	void Update () {
		
	}

    public void ButtonPlay()
    {
        DontPaused();
    }
    public void ButtonReplay()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void ButtonMenu()
    {
        SceneManager.LoadScene("MenuScene");
        Statik.PMenu = true;
    }
    public void ButtonPause()
    {
        Pausemenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void DontPaused()
    {
        Pausemenu.SetActive(false);
        Time.timeScale = 1;
    }
}
