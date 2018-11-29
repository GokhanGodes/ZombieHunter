using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour {


	void Start () {

        if(!PlayerPrefs.HasKey("CoinsCount"))
        {
            Statik.CoinsCount = 0;
        }
        else
        {
            Statik.CoinsCount = PlayerPrefs.GetInt("CoinsCount", Statik.CoinsCount);
            
        }

        Invoke("Destroy", 1);
    }
	
	void Update () {
		
	}
    public void Destroy()
    {
        if (!Statik.HeadShoot)
        {
            Statik.CoinsCount += 1;
            PlayerPrefs.SetInt("CoinsCount", Statik.CoinsCount);
            Destroy(gameObject);
        }
        if(Statik.HeadShoot)
        {
            Statik.CoinsCount += 3;
            PlayerPrefs.SetInt("CoinsCount", Statik.CoinsCount);
            Destroy(gameObject);
        }
        if(Statik.OrcIsDead)
        {
            Statik.CoinsCount += 30;
            PlayerPrefs.SetInt("CoinsCount", Statik.CoinsCount);
            Destroy(gameObject);
            Statik.OrcIsDead = false;
        }
    }
}
