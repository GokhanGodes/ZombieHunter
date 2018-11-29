using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    Rigidbody2D BulletRigid;
    public float BulletSpeed;
	void Start () {
        BulletRigid = GetComponent<Rigidbody2D>();
        if(!PlayerPrefs.HasKey("BulletSpeed"))
        {
            BulletSpeed = 0;
        }
        else
        {
            BulletSpeed = PlayerPrefs.GetFloat("BulletSpeed");
        }
	}
	void Update () {

        BulletRigid.velocity = Vector2.right * 40;
        Invoke("OnDestroyy", 0.5F + BulletSpeed);
	}
    public void OnDestroyy()
    {
        Destroy(gameObject);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        OnDestroyy();
        if (collision.tag == "Head")
        {
            Statik.HeadShoot = true;
        }
    }
    
}
