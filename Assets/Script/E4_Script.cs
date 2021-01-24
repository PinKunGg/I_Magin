using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class E4_Script : MonoBehaviour
{

    public Transform spownPos;
    public GameObject Ice_Bullet;
    public GameObject GameOver;
    public GameObject player;

    public IceBoss_BigMage BigMage;

    [SerializeField] private Animation anima;

    bool bulletspawn = true;
    bool shootingrepeat = true;
    bool Death = false;

    float delay = 0.7f;
    float HpE2 = 30f;

    void Start()
    {
        player = GameObject.Find("Player");
        GameOver = GameObject.Find("Canvas/GameOver");
    }

    void Update()
    {
        if (HpE2 <= 0)
        {
            anima.CrossFade("Anim_Death");
            bulletspawn = false;

            SkillSet();
            Destroy(gameObject, 0.8f);
        }

        RotateETS(this.transform.position.x, this.transform.position.z, player.transform.position.x, player.transform.position.z);
    }

    void SkillSet()
    {
        if (Death == false)
        {
            Death = true;
            BigMage.SkillSet++;
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

    void RotateETS(float selfx, float selfz, float playerx, float playerz)
    {
        float r2d = 57.29578f;
        float theta = r2d * Mathf.Atan2(playerx - selfx, playerz - selfz);
        this.transform.rotation = Quaternion.Euler(0f, theta, 0f);
    }
}
