using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour {

    Rigidbody2D PlayerRigid;
    Animator PlayerAnimator;
    CharacterController CC;
    public float Rotation, Timer = 0.25F,Speed=1,SpeedTime=4F;
    public bool Shoot, Dead, Damage,IsPrefab,Idle=true;
    public GameObject BulletPrefab;
    public Transform BulletPosition;
    public int Health=3;
    public AudioSource Audio;
    public AudioClip ShootSound;
	void Start () {
        PlayerRigid =GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        PlayerAnimator =GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        CC = GameObject.FindGameObjectWithTag("CharacterController").GetComponent<CharacterController>();
        Statik.GOMenu = false;
        Statik.Skor = 0;
        Statik.HealthCount = 0;
        Statik.UPSpeed = 1;
        Statik.PlayerSpeed = 1;
        Statik.ZombieSpeed = 1;
        PlayerPrefs.SetFloat("PlayerSpeed", Statik.PlayerSpeed);
        Time.timeScale = 1;

    }
    void Update () {

        Timer -= Time.deltaTime;
        SpeedTime -= Time.deltaTime;
        if(SpeedTime<=0)
        {
            Speed += (Speed / 100);
            SpeedTime = 4f;
        }
        PlayerAnimator.SetFloat("Speed", Mathf.Abs(Rotation));
        PlayerAnimator.SetBool("Damage", Damage);
        PlayerAnimator.SetBool("Idle", Idle);
        PlayerAnimator.SetBool("Dead", Dead);
       
        //Move();
        if (Input.GetKeyDown(KeyCode.LeftControl) && Health>0)
        {
            Shoot = true;
            Attack();

        }

        if(Health<=0 && Dead==false)
        {
            Dead = true;
            Invoke("OyunSonu",(float) 1);
            Statik.GOMenu = true;
        }


        Damage = false;

    }
    private void LateUpdate()
    {
        if (CC.DownButton)
        {
            PlayerRigid.velocity = Vector2.down * 5 * Speed * PlayerPrefs.GetFloat("PlayerSpeed");
            Rotation = 1;
        }

        if (CC.UpButton)
        {
            PlayerRigid.velocity = Vector2.up * 5 * Speed * PlayerPrefs.GetFloat("PlayerSpeed");
            Rotation = 1;
        }
        if (!CC.UpButton && !CC.DownButton)
        {
            PlayerRigid.velocity = Vector2.up * 0;
            Rotation = 0;
        }
        if (CC.ShootButton)
     {
            if (Health > 0 && Timer <= 0)
            {
                Shoot = true;
                Attack();
                Timer = 0.25F;
            }
            CC.ShootButton = false;
        }
    }
    public void Move()
    {
        Rotation = Input.GetAxis("Horizontal");
        PlayerRigid.velocity = Vector2.up * Rotation * 5 * Speed * PlayerPrefs.GetFloat("PlayerSpeed");
    }
    public void BulletInstantiate()
    {
        if(IsPrefab)
        {
            Instantiate(BulletPrefab, BulletPosition.position, Quaternion.Euler(0, 0, 0));
            IsPrefab = false;
        }
    }
    public void Attack()
    {
        if(PlayerPrefs.GetString("Sounds")=="On")
        {
            Audio.PlayOneShot(ShootSound);
        }
        PlayerAnimator.SetTrigger("Shoot");
        if (Shoot)
        {
            IsPrefab = true;
            BulletInstantiate();
            Shoot = false;
            Idle = true;
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            Damage = true;
        }
    }
    public void OyunSonu()
    {
        Time.timeScale = 0;
    }
}
