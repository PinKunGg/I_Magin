using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindBoss : MonoBehaviour
{

    public int BossHp = 100;

    [SerializeField] private Animator anime;

    bool isHit = false;
    bool isDeath = false;
    bool isAttack = false;
    bool isIdle = true;

    bool bulletspawn = true;
    bool skillspawn = true;
    bool shootingrepeat = true;
    bool PlayerIn = false;

    float delay = 0.7f;
    float delayanimate = 0f;
    public float SkillNum = 1;
    public float shooting = 0;
    public float shootCount = 1;
    public float bulletsw = 1;

    public WindBossHp HpPoint;
    public GameManagementScene1 gm1;

    public Transform SpawnPos1;
    public Transform SpawnPos2;
    public Transform SkillPos;
    public GameObject WindBullet1;
    public GameObject WindSkill1;
    public GameObject WindBossHp;
    public GameObject WindBossHpText;
    public GameObject GameOver;
    public GameObject WindKey;
    public GameObject BGMAudio;
    public GameObject BossAudio;

    // Start is called before the first frame update
    void Start()
    {
        WindKey.SetActive(false);
    }

    // Update is called once per frame
    public void Update()
    {
        anime.SetBool("GetHit", isHit);
        anime.SetBool("Idle", isIdle);
        anime.SetBool("Attack", isAttack);

        if (BossHp <= 0)
        {
            isDeath = true;
            bulletspawn = false;
            shooting = 0;

            BossAudio.SetActive(false);
            BGMAudio.SetActive(true);

            anime.SetBool("Death", isDeath);
            Destroy(this.gameObject, 2f);

            WindKey.SetActive(true);
            gm1.BossDeath();

            Invoke("StopAnimate", 2f);

            Invoke("DisHpBar", 1f);
        }

        BossSkill();
    }

    private void BossSkill()
    {
        if (BossHp <= 75 && SkillNum == 1)
        {
            SkillNum += 1;
            bulletspawn = false;

            Instantiate(WindSkill1, SkillPos.position, SkillPos.rotation);
        }
        if (BossHp <= 50 && SkillNum == 2)
        {
            SkillNum += 1;
            bulletspawn = false;

            Instantiate(WindSkill1, SkillPos.position, SkillPos.rotation);
        }
        if (BossHp <= 25 && SkillNum == 3)
        {
            SkillNum += 1;
            bulletspawn = false;

            Instantiate(WindSkill1, SkillPos.position, SkillPos.rotation);
        }
        if (BossHp <= 0 && SkillNum == 4)
        {
            SkillNum += 1;
            bulletspawn = false;

            Instantiate(WindSkill1, SkillPos.position, SkillPos.rotation);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameOver.gameObject.SetActive(true);
        }

        if(collision.gameObject.tag == "PlayerBullet" && PlayerIn == true)
        {
            HpPoint.HpCount(5);

            BossHp -= 5;

            print("Boss Hp: " + BossHp);

            if (BossHp >= 5)
            {
                isHit = true;

                isIdle = false;
                isAttack = false;
            }

            Invoke("StopAnimate", 1f);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        
    }

    private void OnCollisionExit(Collision collision)
    {
        
    }

    void StopAnimate()
    {
        isIdle = true;
        isHit = false;
        isDeath = false;
    }
    void TriggerStopAnimate()
    {
        isAttack = false;
        isIdle = true;
    }
    void DisHpBar()
    {
        WindBossHp.gameObject.SetActive(false);
        WindBossHpText.gameObject.SetActive(false);
    }

    private void shoot1()
    {
        //===============================================================================
        if (bulletspawn == true && bulletsw == 1)
        {
            Instantiate(WindBullet1, SpawnPos1.position, SpawnPos1.rotation);
            shootCount += 1;
            isAttack = true;
            Invoke("TriggerStopAnimate", 1f);
        }
        //===============================================================================
        if (bulletspawn == true && bulletsw == 2)
        {
            Instantiate(WindBullet1, SpawnPos2.position, SpawnPos2.rotation);
            shootCount += 1;
            isAttack = true;
            Invoke("TriggerStopAnimate", 1f);
        }
        //===============================================================================
        if (bulletspawn == true && bulletsw == 3)
        {
            Instantiate(WindBullet1, SpawnPos1.position, SpawnPos1.rotation);
            shootCount += 1;
            isAttack = true;
            Invoke("TriggerStopAnimate", 1f);
        }
        if (bulletspawn == true && bulletsw == 4)
        {
            Instantiate(WindBullet1, SpawnPos2.position, SpawnPos2.rotation);
            shootCount += 1;
            isAttack = true;
            Invoke("TriggerStopAnimate", 1f);
        }
        //===============================================================================
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && BossHp <= 0 && isDeath == true)
        {
            shooting = 0;
            bulletspawn = false;
        }

        if (other.gameObject.tag == "Player")
        {
            PlayerIn = true;
        }

        if (other.gameObject.tag == "Player" && isDeath == false)
        {
            isIdle = false;
            shooting = 1;

            if (shooting == 1 && shootingrepeat == true)
            {
                InvokeRepeating("shoot1", delay, delay);
                shootingrepeat = false;
                print("Shoot1");
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && BossHp <= 0 && isDeath == true)
        {
            shooting = 0;
            isIdle = false;
            bulletspawn = false;
        }

        if (other.gameObject.tag == "Player")
        {
            isIdle = false;
        }

        if (other.gameObject.tag == "Player" && isDeath == false)
        {
            //===============================================================================
            if (shootCount >= 1 && shootCount <= 3 && bulletsw == 1)
            {
                bulletspawn = true;
            }
            if (shootCount > 3 && bulletsw == 1)
            {
                bulletspawn = false;
                bulletsw = 2;
                shooting = 2;
                shootCount = 1;
            }
            //===============================================================================
            if (shootCount >= 1 && shootCount <= 3 && bulletsw == 2)
            {
                bulletspawn = true;
            }
            if (shootCount > 3 && bulletsw == 2)
            {
                bulletspawn = false;
                bulletsw = 3;
                shooting = 3;
                shootCount = 1;
            }
            //===============================================================================
            if (shootCount >= 1 && shootCount <= 3 && (bulletsw == 3 || bulletsw == 4))
            {
                bulletspawn = true;
                bulletsw = 4;
            }
            if (bulletsw == 4 && (shootCount == 1 || shootCount == 3))
            {
                bulletsw = 3;
            }
            if (shootCount > 3 && (bulletsw == 3 || bulletsw == 4))
            {
                bulletspawn = false;
                bulletsw = 1;
                shooting = 1;
                shootCount = 1;
            }
            //===============================================================================
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            PlayerIn = false;

            isIdle = true;
            bulletspawn = false;
            shooting = 0;

            Invoke("TriggerStopAnimate", 1f);
        }
    }
}
