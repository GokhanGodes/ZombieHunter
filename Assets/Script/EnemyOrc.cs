using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyOrc : MonoBehaviour
{

    CharacterController CC;
    Character C;
    Rigidbody2D OrcRigid;
    Animator OrcAnimator;
    public Blood OrcBlood;
    public float Speed = 1f;
    public int Health = 400, Count = 0, Skor;
    public bool Damage, Dead, Sound,Attack;
    public GameObject CoinsPrefab,MalletPrefab,SwordPrefab,LabrysPrefab;
    public AudioSource EnemySource;
    public AudioClip BleedSound, DeadSound;
    public CapsuleCollider2D Collider;
    public Transform MalletPosition,SwordPosition,LabrysPosition;
    public float Timer = 5;

    void Start()
    {
        OrcRigid = GetComponent<Rigidbody2D>();
        OrcAnimator = GetComponent<Animator>();
        CC = GameObject.FindGameObjectWithTag("CharacterController").GetComponent<CharacterController>();
        C = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
        Statik.OrcIsDead = false;
        Sound = true;
    }

    void Update()
    {
        OrcAnimator.SetBool("Dead", Dead);
        OrcAnimator.SetBool("Damage", Damage);
        OrcAnimator.SetBool("Attack", Attack);
        Timer -= Time.deltaTime;
        if (Timer<=0)
        {
            Attacking();
            Attack = false;
            Timer = 5;
        }
        if (Health <= 0)
        {
            Dead = true;
            Speed = 0;
            Invoke("Destroy", 1);

        }
        Damage = false;
        OrcRigid.velocity = Vector2.left * 1 * Speed;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet" && Health > 0)
        {
            OrcBlood.Bleed = true;
            Damage = true;
            EnemySource.PlayOneShot(BleedSound);
            Health -= 25 + (int)PlayerPrefs.GetFloat("GunPower");
        }
        if (collision.tag == "Bullet" && Health <= 0 && Sound)
        {
            EnemySource.PlayOneShot(DeadSound);
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
        if (collision.gameObject.tag == "Player" && Health > 0)
        {
            OnDamage();
            Destroy(gameObject);
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
        if (!Statik.HeadShoot)
        {
            Statik.Skor+=15;
            CoinsInstantiate();
        }
        if (Statik.HeadShoot)
        {
            Statik.Skor += 20;
            CoinsInstantiate();
        }


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
        if (Dead && Count == 0)
        {
            Instantiate(CoinsPrefab, transform.position, Quaternion.identity);
            Statik.OrcIsDead = true;
            Count++;
        }
    }
    public void Attacking()
    {
        Attack = true;
        OrcAnimator.SetBool("Attack", Attack);

        if(Attack)
        {
            StartCoroutine(Ataktime());
        }

    }
    IEnumerator Ataktime()
    {
        yield return new WaitForSeconds(0.75F);
        if(gameObject.name=="Orc1(Clone)")
        {
            Instantiate(MalletPrefab, MalletPosition.position, Quaternion.identity);
            Attack = false;
        }
        if(gameObject.name=="Orc2(Clone)")
        {
            Instantiate(SwordPrefab, SwordPosition.position, Quaternion.identity);
            Attack = false;
        }
        if (gameObject.name == "Orc3(Clone)")
        {
            Instantiate(LabrysPrefab, LabrysPosition.position, Quaternion.identity);
            Attack = false;
        }


    }
}

