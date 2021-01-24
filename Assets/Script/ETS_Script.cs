using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ETS_Script : MonoBehaviour
{
    public Transform spownPos;
    public GameObject Thunder_Bullet;
    public GameObject GameOver;
    public GameObject player;

    [SerializeField] private Animator anima;

    bool isAttack = false;
    bool isDamage = false;
    bool isDeath = false;
    bool isIdle = true;

    bool bulletspawn = true;
    bool shootingrepeat = true;
    float delay = 0.7f;

    float HpE2 = 30f;

    void Start()
    {

    }

    void Update()
    {
        anima.SetBool("Idle", isIdle);
        anima.SetBool("Attack", isAttack);
        anima.SetBool("Damage", isDamage);
        anima.SetBool("Death", isDeath);

        if (HpE2 <= 0)
        {
            isDeath = true;

            isIdle = false;
            isAttack = false;

            bulletspawn = false;

            Destroy(gameObject, 1f);
        }

        RotateETS(this.transform.position.x, this.transform.position.z, player.transform.position.x, player.transform.position.z);
    }

    private void shoot()
    {
        if (bulletspawn == true)
        {
            Instantiate(Thunder_Bullet, spownPos.position, spownPos.rotation);
        }
    }

    void TriggerStopAnimate()
    {
        isIdle = true;
        isAttack = false;
        isDamage = false;
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

            HpE2 -= 10;

            print(HpE2);

            Invoke("TriggerStopAnimate", 1f);
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

        if (collision.gameObject.tag == "Player" && HpE2 > 0)
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

    void RotateETS(float selfx, float selfz, float playerx, float playerz)
    {
        float r2d = 57.29578f;
        float theta = r2d * Mathf.Atan2(playerx - selfx, playerz - selfz);
        this.transform.rotation = Quaternion.Euler(0f, theta, 0f);
    }
}
