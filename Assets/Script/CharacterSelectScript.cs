using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelectScript : MonoBehaviour {

    public Image[] Selecteds;
    public int Selected;
	void Start () {

        if (!PlayerPrefs.HasKey("Selected"))
        {
            Selected = 0;
            Statik.Selected = 0;
            PlayerPrefs.SetInt("Selected", Selected);
        }
        else
        {
            Selected = PlayerPrefs.GetInt("Selected");
            Statik.Selected = Selected;
            Selecteds[0].enabled = false;
            Selecteds[1].enabled = false;
            Selecteds[2].enabled = false;
            Selecteds[3].enabled = false;
            Selecteds[4].enabled = false;
            Selecteds[5].enabled = false;
            Selecteds[6].enabled = false;
            Selecteds[7].enabled = false;
            Selecteds[Selected].enabled = true;
        }
	}
	

	void Update () {

        PlayerPrefs.SetInt("Selected", Selected);
        Statik.Selected = Selected;
		
	}
    public void OnBack()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void Button1()
    {
        Selecteds[0].enabled = true;
        Selecteds[1].enabled = false;
        Selecteds[2].enabled = false;
        Selecteds[3].enabled = false;
        Selecteds[4].enabled = false;
        Selecteds[5].enabled = false;
        Selecteds[6].enabled = false;
        Selecteds[7].enabled = false;
        Selected = 0;
    }
    public void Button2()
    {
        Selecteds[0].enabled = false;
        Selecteds[1].enabled = true;
        Selecteds[2].enabled = false;
        Selecteds[3].enabled = false;
        Selecteds[4].enabled = false;
        Selecteds[5].enabled = false;
        Selecteds[6].enabled = false;
        Selecteds[7].enabled = false;
        Selected = 1;
    }
    public void Button3()
    {
        Selecteds[0].enabled = false;
        Selecteds[1].enabled = false;
        Selecteds[2].enabled = true;
        Selecteds[3].enabled = false;
        Selecteds[4].enabled = false;
        Selecteds[5].enabled = false;
        Selecteds[6].enabled = false;
        Selecteds[7].enabled = false;
        Selected = 2;
    }
    public void Button4()
    {
        Selecteds[0].enabled = false;
        Selecteds[1].enabled = false;
        Selecteds[2].enabled = false;
        Selecteds[3].enabled = true;
        Selecteds[4].enabled = false;
        Selecteds[5].enabled = false;
        Selecteds[6].enabled = false;
        Selecteds[7].enabled = false;
        Selected = 3;
    }
    public void Button5()
    {
        Selecteds[0].enabled = false;
        Selecteds[1].enabled = false;
        Selecteds[2].enabled = false;
        Selecteds[3].enabled = false;
        Selecteds[4].enabled = true;
        Selecteds[5].enabled = false;
        Selecteds[6].enabled = false;
        Selecteds[7].enabled = false;
        Selected = 4;
    }
    public void Button6()
    {
        Selecteds[0].enabled = false;
        Selecteds[1].enabled = false;
        Selecteds[2].enabled = false;
        Selecteds[3].enabled = false;
        Selecteds[4].enabled = false;
        Selecteds[5].enabled = true;
        Selecteds[6].enabled = false;
        Selecteds[7].enabled = false;
        Selected = 5;
    }
    public void Button7()
    {
        Selecteds[0].enabled = false;
        Selecteds[1].enabled = false;
        Selecteds[2].enabled = false;
        Selecteds[3].enabled = false;
        Selecteds[4].enabled = false;
        Selecteds[5].enabled = false;
        Selecteds[6].enabled = true;
        Selecteds[7].enabled = false;
        Selected = 6;
    }
    public void Button8()
    {
        Selecteds[0].enabled = false;
        Selecteds[1].enabled = false;
        Selecteds[2].enabled = false;
        Selecteds[3].enabled = false;
        Selecteds[4].enabled = false;
        Selecteds[5].enabled = false;
        Selecteds[6].enabled = false;
        Selecteds[7].enabled = true;
        Selected = 7;
    }
}
