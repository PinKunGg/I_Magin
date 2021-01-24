using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IceBoss : MonoBehaviour
{

    public int BossHp = 100;

    [SerializeField] private Animator anime;

    bool isHit = false;
    bool isDeath = false;
    bool isAttack = false;
    bool isIdle = true;

    bool bulletspawn = true;
    bool shootingrepeat = true;
    bool PlayerIn = false;
    bool isSkill = false;

    int shootCount = 1;
    int bulletsw = 1;
    int shooting = 1;
    int SkillCount = 1;

    public bool Cinematic = true;

    float delay = 1f;

    public IceBossHp HpPoint;

    public Transform SpawnPos1;
    public Transform SpawnPos2;
    public Transform SkillHor1;
    public GameObject IceSpikeSkill1;
    public GameObject InceBullet1;
    public GameObject IceBossHp;
    public GameObject IceBossHpText;
    public GameObject GameOver;

    public IceBossCinematic icebosscinematic;

    // Start is called before the first frame update
    void Start()
    {
        
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

            anime.SetBool("Death", isDeath);
            Destroy(this.gameObject, 2f);

            Invoke("StopAnimate", 1f);

            Invoke("DisHpBar", 1f);
        }
        StartCoroutine(BossSkill1());

    }

    IEnumerator BossSkill1()
    {
        if (BossHp <= 75 && SkillCount == 1)
        {
            isSkill = false;
            SkillCount++;
            IceSpikeSkill1.SetActive(true);
            yield return new WaitForSeconds(3f);
            isSkill = false;
            yield return new WaitForSeconds(0.5f);
            IceSpikeSkill1.SetActive(false);
        }
        if (BossHp <= 50 && SkillCount == 2)
        {
            isSkill = false;
            SkillCount++;
            IceSpikeSkill1.SetActive(true);
            yield return new WaitForSeconds(3f);
            isSkill = false;
            yield return new WaitForSeconds(0.5f);
            IceSpikeSkill1.SetActive(false);
        }
        if (BossHp <= 25)
        {
            bulletspawn = false;
            icebosscinematic.gameObject.SetActive(true);
            icebosscinematic.CinematicStage2();
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

                isAttack = false;
                isIdle = false;
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
        isHit = false;
        isDeath = false;
    }

    void DisHpBar()
    {
        IceBossHp.gameObject.SetActive(false);
        IceBossHpText.gameObject.SetActive(false);
    }

    void TriggerStopAnimate()
    {
        isAttack = false;
        isIdle = true;
    }

    private void shoot1()
    {
        //===============================================================================
        if (bulletspawn == true && bulletsw == 1)
        {
            if (isSkill == false)
            {
                Instantiate(InceBullet1, SpawnPos1.position, SpawnPos1.rotation);
                shootCount += 1;
            }
            isAttack = true;
            Invoke("TriggerStopAnimate", 1.2f);
        }
        //===============================================================================
        if (bulletspawn == true && bulletsw == 2)
        {
            if (isSkill == false)
            {
                Instantiate(InceBullet1, SpawnPos2.position, SpawnPos2.rotation);
                shootCount += 1;
            }
            isAttack = true;
            Invoke("TriggerStopAnimate", 1.2f);
        }
        //===============================================================================
        if (bulletspawn == true && bulletsw == 3)
        {
            if (isSkill == false)
            {
                Instantiate(InceBullet1, SpawnPos1.position, SpawnPos1.rotation);
                shootCount += 1;
            }
            isAttack = true;
            Invoke("TriggerStopAnimate", 1.2f);
        }
        if (bulletspawn == true && bulletsw == 4)
        {
            if (isSkill == false)
            {
                Instantiate(InceBullet1, SpawnPos2.position, SpawnPos2.rotation);
                shootCount += 1;
            }
            isAttack = true;
            Invoke("TriggerStopAnimate", 1.2f);
        }
        //===============================================================================
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Cinematic == false)
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
                    InvokeRepeating("shoot1", 0.5f, delay);
                    shootingrepeat = false;
                    print("Shoot1");
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Cinematic == false)
        {
            if (other.gameObject.tag == "Player" && BossHp <= 0 && isDeath == true)
            {
                shooting = 0;
                isIdle = false;
                bulletspawn = false;
            }

            if (other.gameObject.tag == "Player")
            {
                PlayerIn = true;
                isIdle = false;
            }

            if (other.gameObject.tag == "Player" && isDeath == false)
            {
                if (shooting == 1 && shootingrepeat == true)
                {
                    InvokeRepeating("shoot1", 0.5f, delay);
                    shootingrepeat = false;
                    print("Shoot1");
                }

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
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            PlayerIn = false;

            isIdle = true;
            bulletspawn = false;
            shooting = 0;

            Invoke("TriggerStopAnimate", 1.2f);
        }
    }
}
