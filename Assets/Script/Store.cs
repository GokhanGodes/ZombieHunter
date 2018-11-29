using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Store : MonoBehaviour {

    public Image[] GunYellows, BulletYellows,SpeedYellows;
    public int GunCount, BulletCount, SpeedCount;
    public Text GunCoins, BulletCoins, SpeedCoins,MainCoins;
    public Button[] Butons;

	void Start () {

        //ResetAll();

        if (!PlayerPrefs.HasKey("GunCount"))
        {
            GunCount = 0;
            Statik.UPGun = 250;
            PlayerPrefs.SetInt("UPGun", Statik.UPGun);
            Statik.GunPower = 0;
            PlayerPrefs.SetFloat("GunPower", Statik.GunPower);
        }
        else
        {
            GunCount = PlayerPrefs.GetInt("GunCount");
            Statik.GunPower = PlayerPrefs.GetFloat("GunPower");
            if(GunCount<6)
            {
                for (int i = 0; i < GunCount; i++)
                {
                    GunYellows[i].enabled = true;
                }
            }
            GunCoins.text = PlayerPrefs.GetInt("UPGun").ToString();
        }
        if (!PlayerPrefs.HasKey("BulletCount"))
        {
            BulletCount = 0;
            Statik.UPBullet = 250;
            Statik.BulletSpeed = 0;
            PlayerPrefs.SetFloat("BulletSpeed", Statik.BulletSpeed);
            PlayerPrefs.SetInt("UPBullet", Statik.UPBullet);
        }
        else
        {
            BulletCount = PlayerPrefs.GetInt("BulletCount");
            Statik.BulletSpeed = PlayerPrefs.GetFloat("BulletSpeed");
            if (BulletCount < 6)
            {
                for (int i = 0; i < BulletCount; i++)
                {
                    BulletYellows[i].enabled = true;
                }
            }
            BulletCoins.text = PlayerPrefs.GetInt("UPBullet").ToString();
        }
        if (!PlayerPrefs.HasKey("SpeedCount"))
        {
            SpeedCount = 0;
            Statik.UPSpeed = 250;
            Statik.PlayerSpeed = 1;
            PlayerPrefs.SetFloat("PlayerSpeed", Statik.PlayerSpeed);
            PlayerPrefs.SetInt("UPSpeed", Statik.UPSpeed);
        }
        else
        {
            SpeedCount = PlayerPrefs.GetInt("SpeedCount");
            Statik.PlayerSpeed = PlayerPrefs.GetFloat("PlayerSpeed");
            if (SpeedCount < 6)
            {
                for (int i = 0; i < SpeedCount; i++)
                {
                    SpeedYellows[i].enabled = true;
                }
            }
            SpeedCoins.text = PlayerPrefs.GetInt("UPSpeed").ToString();
        }
    }
	void Update () {

        MainCoinsUpgrade();
        if (GunCount == 5)
        {
            GunCoins.text = "Max Level";
            Butons[1].interactable = false;
        }
        if (BulletCount == 5)
        {
            BulletCoins.text = "Max Level";
            Butons[2].interactable = false;
        }
        if (SpeedCount == 5)
        {
            SpeedCoins.text = "Max Level";
            Butons[0].interactable = false;
        }
    }

    public void GunUpgrade()
    {
        if (Statik.CoinsCount>=Statik.UPGun && GunCount<=5)
        {
            GunCount++;
            PlayerPrefs.SetInt("GunCount", GunCount);
            Statik.GunPower += 10;
            PlayerPrefs.SetFloat("GunPower", Statik.GunPower);
            for (int i = 0; i < GunCount; i++)
            {
                GunYellows[i].enabled = true;
            }
            Statik.CoinsCount -= Statik.UPGun;
            PlayerPrefs.SetInt("CoinsCount", Statik.CoinsCount);
            MainCoinsUpgrade();
            Statik.UPGun *= 2;
            PlayerPrefs.SetInt("UPGun", Statik.UPGun);
            GunCoins.text = Statik.UPGun.ToString();
            if (GunCount == 5)
            {
                GunCoins.text = "Max Level";
            }

        }

    }
    public void BulletUpgrade()
    {
        if (Statik.CoinsCount >= Statik.UPBullet && BulletCount<=5)
        {
            BulletCount++;
            PlayerPrefs.SetInt("BulletCount", BulletCount);
            Statik.BulletSpeed += 0.09F;
            PlayerPrefs.SetFloat("BulletSpeed", Statik.BulletSpeed);
            for (int i = 0; i < BulletCount; i++)
            {
                BulletYellows[i].enabled = true;
            }
            Statik.CoinsCount -= Statik.UPBullet;
            PlayerPrefs.SetInt("CoinsCount", Statik.CoinsCount);
            MainCoinsUpgrade();
            Statik.UPBullet *= 2;
            PlayerPrefs.SetInt("UPBullet", Statik.UPBullet);
            BulletCoins.text = Statik.UPBullet.ToString();
            if (BulletCount == 5)
            {
                BulletCoins.text = "Max Level";
            }

        }

    }
    public void SpeedUpgrade()
    {
        if (Statik.CoinsCount >= Statik.UPSpeed && SpeedCount<=5)
        {
            SpeedCount++;
            PlayerPrefs.SetInt("SpeedCount", SpeedCount);
            Statik.PlayerSpeed += 0.2F;
            PlayerPrefs.SetFloat("PlayerSpeed", Statik.PlayerSpeed);
            for (int i = 0; i < SpeedCount; i++)
            {
                SpeedYellows[i].enabled = true;
            }
            Statik.CoinsCount -= Statik.UPSpeed;
            PlayerPrefs.SetInt("CoinsCount", Statik.CoinsCount);
            MainCoinsUpgrade();
            Statik.UPSpeed *= 2;
            PlayerPrefs.SetInt("UPSpeed", Statik.UPSpeed);
            SpeedCoins.text = Statik.UPSpeed.ToString();
            if (SpeedCount == 5)
            {
                SpeedCoins.text = "Max Level";
            }
        }

    }
    public void HomeButton()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void MainCoinsUpgrade()
    {
        Statik.CoinsCount = PlayerPrefs.GetInt("CoinsCount");
        MainCoins.text = Statik.CoinsCount.ToString();
        BulletCoins.text = PlayerPrefs.GetInt("UPBullet").ToString();
        SpeedCoins.text = PlayerPrefs.GetInt("UPSpeed").ToString();
        GunCoins.text = PlayerPrefs.GetInt("UPGun").ToString();

    }
    public void ResetAll()
    {
        PlayerPrefs.DeleteKey("GunCount");
        PlayerPrefs.DeleteKey("BulletCount");
        PlayerPrefs.DeleteKey("SpeedCount");
        PlayerPrefs.DeleteKey("BulletSpeed");
        PlayerPrefs.DeleteKey("GunPower");
        PlayerPrefs.DeleteKey("PlayerSpeed");
        PlayerPrefs.SetInt("CoinsCount",100);
    }
}
