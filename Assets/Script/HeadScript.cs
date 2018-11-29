using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadScript : MonoBehaviour {

    public GameObject HeadShoot;
    Enemy Zombie;
	void Start () {
        Zombie = GetComponentInParent<Enemy>();
        HeadShoot.SetActive(false);



    }

    void Update () {
		
	}
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Bullet")
        {
            HeadShoot.SetActive(true);
            Zombie.Health = 0;
            if (PlayerPrefs.GetString("Sounds") == "On")
            {
                Zombie.EnemySource.PlayOneShot(Zombie.BleedSound);
            }
            Statik.HeadShoot = true;
        }
    }
}
