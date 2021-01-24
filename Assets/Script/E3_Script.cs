using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class E3_Script : MonoBehaviour
{

    public Transform spownPos;
    public GameObject Ice_Bullet;
    public GameObject GameOver;

    [SerializeField] private Animation anima;

    bool bulletspawn = true;
    bool shootingrepeat = true;

    float delay = 0.7f;
    float HpE2 = 30f;

    void Start()
    {

    }

    void Update()
    {
        if (HpE2 <= 0)
        {
            anima.CrossFade("Anim_Death");

            bulletspawn = false;

            Destroy(gameObject, 0.8f);
        }
    }

    private void shoot()
    {
        if (bulletspawn == true)
        {
            Instantiate(Ice_Bullet, spownPos.position, spownPos.rotation);
        }
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
            anima.CrossFade("Anim_Damage");

            HpE2 -= 10;

            print(HpE2);
        }

        anima.CrossFadeQueued("Anim_Idle");
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anima.CrossFade("Anim_Attack");

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
            anima.CrossFade("Anim_Attack");
        }

        if (collision.gameObject.tag == "Player" && HpE2 > 0)
        {
            bulletspawn = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anima.Stop();
            anima.CrossFade("Anim_Idle");
            bulletspawn = false;
        }
    }
}
