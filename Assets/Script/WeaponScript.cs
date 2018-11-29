using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{

    Rigidbody2D WeaponRigid;
    Character C;
    CharacterController CC;
    public float WeaponSpeed;

    void Start()
    {
        WeaponRigid = GetComponent<Rigidbody2D>();
        C = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
        CC = GameObject.FindGameObjectWithTag("CharacterController").GetComponent<CharacterController>();
    }
    void Update()
    {

        WeaponRigid.velocity = Vector2.left * 10;
        transform.Rotate(0, 0, 10);
        Invoke("OnDestroyy", 2.5F + WeaponSpeed);
    }
    public void OnDestroyy()
    {
        Destroy(gameObject);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            OnDamage();
            OnDestroyy();
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

}
