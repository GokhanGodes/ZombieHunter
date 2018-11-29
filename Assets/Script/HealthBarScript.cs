using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour {

    public GameObject HealthBar;
    public Image HealthImage;
    Enemy E;
	void Start () {
        HealthBar.SetActive(true);
        E = GetComponentInParent<Enemy>();


		
	}
	
	void Update () {

        HealthImage.fillAmount = (float)E.Health / 100;
        if(E.Health<=0)
        {
            HealthBar.SetActive(false);
        }
    }
}
