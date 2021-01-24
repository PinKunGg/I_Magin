using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class E1_Script : MonoBehaviour
{

    public Transform spownPos;
    public GameObject Wind_Bullet;
    public GameObject GameOver;
    public GameObject BGMAudio;

    [SerializeField] private Animator anima;

    bool isAttack = false;
    bool isDamage = false;
    bool isDeath = false;
    bool isIdle = true;

    bool bulletspawn = true;
    bool shootingrepeat = true;

    float delay = 0.7f;
    float HpE1 = 30f;

    void Start()
    {

    }

    void Update()
    {
        anima.SetBool("Idle", isIdle);
        anima.SetBool("Attack", isAttack);
        anima.SetBool("Damage", isDamage);
        anima.SetBool("Death", isDeath);

        if (HpE1 <= 0)
        {
            isDeath = true;

            //isIdle = false;
            //isAttack = false;

            bulletspawn = false;

            Destroy(gameObject, 1f);
        }
    }

    private void shoot()
    {
        if (bulletspawn == true)
        {
            Instantiate(Wind_Bullet, spownPos.position, spownPos.rotation);
        }
    }

    void StopAnimation()
    {
        isIdle = true;
        isDamage = false;
    }
    void TriggerStopAnimate()
    {
        isIdle = true;
        isAttack = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")                    
        {
            GameOver.gameObject.SetActive(true);
            Time.timeScale = 0;
        }

        if (collision.gameObject.tag == "PlayerBullet")
        {
            isDamage = true;

            isAttack = false;
            isIdle = false;

            HpE1 -= 10;

            print(HpE1);

            Invoke("StopAnimation", 0.2f);
        }
    }
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isIdle = false;
            isAttack = true;
            Invoke("TriggerStopAnimate", 1f);

            if (shootingrepeat == true)
            {
                InvokeRepeating("shoot", delay, delay);
                shootingrepeat = false;
            }
        }
    }

    private void OnTriggerStay(Collider collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            isIdle = false;
            isAttack = true;

            Invoke("TriggerStopAnimate", 1f);
        }

        if (collision.gameObject.tag == "Player" && HpE1 > 0)
        {
            bulletspawn = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isIdle = true;
            isAttack = false;
            bulletspawn = false;

            Invoke("TriggerStopAnimate", 1f);
        }
    }
}
