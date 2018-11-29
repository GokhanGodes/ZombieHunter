using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour {

    CharacterController CC;
    Character C;
    Rigidbody2D ZombieRigid;
    Animator ZombieAnimator;
    public Blood ZombieBlood;
    public float Speed = 1.5f;
    public int Health = 100,Count=0,Skor;
    public bool Damage, Dead,Sound;
    public GameObject CoinsPrefab;
    public AudioSource EnemySource;
    public AudioClip BleedSound,DeadSound;
    public CapsuleCollider2D Collider;

	void Start () {
        ZombieRigid = GetComponent<Rigidbody2D>();
        ZombieAnimator = GetComponent<Animator>();
        CC = GameObject.FindGameObjectWithTag("CharacterController").GetComponent<CharacterController>();
        C = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
        Sound = true;
    }
	

	void Update () {
        ZombieAnimator.SetBool("Dead", Dead);
        ZombieAnimator.SetBool("Damage", Damage);
        if (Health<=0)
        {
            Dead = true;
            Speed = 0;
            Invoke("Destroy", 1);

        }
        Damage = false;
        ZombieRigid.velocity = Vector2.left * 3*Speed*Statik.ZombieSpeed;

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Bullet" && Health>0)
        {
            ZombieBlood.Bleed = true;
            Damage = true;
            if (PlayerPrefs.GetString("Sounds") == "On")
            {
                EnemySource.PlayOneShot(BleedSound);
            }
            Health -= 25+ (int) PlayerPrefs.GetFloat("GunPower");
        }
        if (collision.tag == "Bullet" && Health <= 0 && Sound)
        {
            if (PlayerPrefs.GetString("Sounds") == "On")
            {
                EnemySource.PlayOneShot(DeadSound);
            }
            Collider.enabled = false;
            Sound = false;
        }
        if (collision.tag == "LeftEdge" && Health > 0)
        {
            Destroy(gameObject);
            OnDamage();
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && Health>0)
        {
            OnDamage();
            Destroy(gameObject);
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
        if(!Statik.HeadShoot)
        {
            Statik.Skor++;
            CoinsInstantiate();
        }
        if (Statik.HeadShoot)
        {
            Statik.Skor+=3;
            CoinsInstantiate();
        }
        Statik.HeadShoot = false;


    }
    public void OnDamage()
    {
        if (Statik.HealthCount >= 0 && Statik.HealthCount < 3)
        {
            CC.HealthSystem[Statik.HealthCount].enabled = false;

        }
        C.Health--;
        Statik.HealthCount++;
    }
    public void CoinsInstantiate()
    {
        if (Dead && Count==0)
        {
            Instantiate(CoinsPrefab, transform.position, Quaternion.identity);
            Count++;
        }
    }
}
