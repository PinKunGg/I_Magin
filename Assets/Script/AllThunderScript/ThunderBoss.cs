using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderBoss : MonoBehaviour
{

    public int BossHp = 100;

    [SerializeField] private Animator anime;

    bool isHit = false;
    bool isDeath = false;
    bool isAttack = false;
    bool isIdle = true;

    bool bulletspawn = true;
    bool shootingrepeat = true;
    bool isSkill = false;
    bool PlayerIn = false;

    float delay = 1f;
    float delayanimate = 0f;
    public float SkillNum = 1;
    public float bulletsw = 1;
    public float shooting = 0;
    public float shootCount = 1;

    public ThunderBossHp HpPoint;
    public GameManagementScene2 gm2;

    public Transform SpawnPos1;
    public Transform SpawnPos2;
    public GameObject SkillVerPos1;
    public GameObject SkillVerPos2;
    public GameObject SkillVerPos3;
    public GameObject SkillHorPos;
    public GameObject ThunderBullet1;
    public GameObject ThunderBossHp;
    public GameObject ThunderBossHpText;
    public GameObject GameOver;
    public GameObject Bridge;
    public GameObject ThunderKey;
    public GameObject BGMAudio;
    public GameObject BossAudio;

    // Start is called before the first frame update
    void Start()
    {
        ThunderKey.SetActive(false);
        SkillVerPos1.SetActive(false);
        SkillVerPos2.SetActive(false);
        SkillVerPos3.SetActive(false);
        SkillHorPos.SetActive(false);
    }

    // Update is called once per frame
    public void Update()
    {
        anime.SetBool("GetHit", isHit);
        anime.SetBool("Idle", isIdle);
        anime.SetBool("Attack", isAttack);

        if (BossHp <= 0)
        {
            BossAudio.SetActive(false);
            BGMAudio.SetActive(true);

            Bridge.SetActive(true);

            isDeath = true;

            anime.SetBool("Death", isDeath);
            Destroy(this.gameObject, 2f);

            gm2.BossDeath();
            ThunderKey.SetActive(true);

            Invoke("StopAnimate", 2f);

            Invoke("DisHpBar", 1f);
        }

        StartCoroutine(BossSkill());
    }

    IEnumerator BossSkill()
    {
        if (BossHp <= 75 && SkillNum == 1)
        {
            SkillNum += 1;
            bulletspawn = false;
            isSkill = true;

            SkillVerPos1.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            SkillVerPos2.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            SkillVerPos3.SetActive(true);
            //===============================================================================
            yield return new WaitForSeconds(0.5f);
            SkillVerPos1.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            SkillVerPos2.SetActive(false);
            isSkill = false;
            yield return new WaitForSeconds(0.5f);
            SkillVerPos3.SetActive(false);
        }
        if (BossHp <= 65 && SkillNum == 2)
        {
            SkillNum += 1;
            bulletspawn = false;
            isSkill = true;

            SkillHorPos.SetActive(true);
            yield return new WaitForSeconds(1f);
            SkillHorPos.SetActive(false);
            isSkill = false;
        }
        if (BossHp <= 50 && SkillNum == 3)
        {
            SkillNum += 1;
            bulletspawn = false;
            isSkill = true;

            SkillVerPos1.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            SkillVerPos2.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            SkillVerPos3.SetActive(true);
            //===============================================================================
            yield return new WaitForSeconds(0.5f);
            SkillVerPos1.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            SkillVerPos2.SetActive(false);
            isSkill = false;
            yield return new WaitForSeconds(0.5f);
            SkillVerPos3.SetActive(false);
        }
        if (BossHp <= 35 && SkillNum == 4)
        {
            SkillNum += 1;
            bulletspawn = false;
            isSkill = true;

            SkillHorPos.SetActive(true);
            yield return new WaitForSeconds(1f);
            SkillHorPos.SetActive(false);
            isSkill = false;
        }
        if (BossHp <= 25 && SkillNum == 5)
        {
            SkillNum += 1;
            bulletspawn = false;
            isSkill = true;

            SkillVerPos1.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            SkillVerPos2.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            SkillVerPos3.SetActive(true);
            //===============================================================================
            yield return new WaitForSeconds(0.5f);
            SkillVerPos1.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            SkillVerPos2.SetActive(false);
            isSkill = false;
            yield return new WaitForSeconds(0.5f);
            SkillVerPos3.SetActive(false);
        }
        if (BossHp <= 0 && SkillNum == 6)
        {
            SkillNum += 1;
            bulletspawn = false;
            isSkill = true;

            SkillVerPos1.SetActive(true);
            SkillVerPos2.SetActive(true);
            SkillVerPos3.SetActive(true);
            SkillHorPos.SetActive(true);
            //===============================================================================
            yield return new WaitForSeconds(0.5f);
            isSkill = false;
            SkillVerPos1.SetActive(false);
            SkillVerPos2.SetActive(false);
            SkillVerPos3.SetActive(false);
            SkillHorPos.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameOver.gameObject.SetActive(true);
            PlayerIn = true;
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

            Invoke("StopAnimate", 0.5f);
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

    void DisHpBar()
    {
        ThunderBossHp.gameObject.SetActive(false);
        ThunderBossHpText.gameObject.SetActive(false);
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
                Instantiate(ThunderBullet1, SpawnPos1.position, SpawnPos1.rotation);
            }
            shootCount += 1;
            isAttack = true;
            Invoke("TriggerStopAnimate", 1.3f);
        }
        //===============================================================================
        if (bulletspawn == true && bulletsw == 2)
        {
            if (isSkill == false)
            {
                Instantiate(ThunderBullet1, SpawnPos2.position, SpawnPos2.rotation);
            }
            shootCount += 1;
            isAttack = true;
            Invoke("TriggerStopAnimate", 1.3f);
        }
        //===============================================================================
        if (bulletspawn == true && bulletsw == 3)
        {
            if (isSkill == false)
            {
                Instantiate(ThunderBullet1, SpawnPos1.position, SpawnPos1.rotation);
            }
            shootCount += 1;
            isAttack = true;
            Invoke("TriggerStopAnimate", 1.3f);
        }
        if (bulletspawn == true && bulletsw == 4)
        {
            if (isSkill == false)
            {
                Instantiate(ThunderBullet1, SpawnPos2.position, SpawnPos2.rotation);
            }
            shootCount += 1;
            isAttack = true;
            Invoke("TriggerStopAnimate", 1.3f);
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
            isAttack = true;
            Invoke("TriggerStopAnimate", 1.3f);

            if (shootingrepeat == true)
            {
                InvokeRepeating("shoot1", delay, delay);
                shootingrepeat = false;
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

            Invoke("TriggerStopAnimate", 1.3f);
        }
    }
}
