using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundScript : MonoBehaviour {

    public Image[] SoundsImage;
	void Start () {
        
        if(!PlayerPrefs.HasKey("Sounds"))
        {
            PlayerPrefs.SetString("Sounds", "On");
            SoundsImage[0].enabled = true;
            SoundsImage[1].enabled = false;
        }
        else
        {
            if(PlayerPrefs.GetString("Sounds")=="On")
            {
                SoundsImage[0].enabled = true;
                SoundsImage[1].enabled = false;
            }
            else
            {
                SoundsImage[0].enabled = false;
                SoundsImage[1].enabled = true;
            }
        }
		
	}
	
	void Update () {
		
	}
    public void ClickSoundButton()
    {
        //SoundsImage[0].enabled = !SoundsImage[0].enabled;
        //SoundsImage[1].enabled = !SoundsImage[1].enabled;
        if (PlayerPrefs.GetString("Sounds") == "On")
        {
            SoundsImage[0].enabled = false;
            SoundsImage[1].enabled = true;
            PlayerPrefs.SetString("Sounds", "Off");
        }
        else
        {
            SoundsImage[0].enabled = true;
            SoundsImage[1].enabled = false;
            PlayerPrefs.SetString("Sounds", "On");
        }
    }
}
