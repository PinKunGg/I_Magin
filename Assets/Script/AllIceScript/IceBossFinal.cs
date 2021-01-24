using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IceBossFinal : MonoBehaviour
{

    public int BossHp = 200;

    [SerializeField] private Animator anime;

    public bool isHit = false;
    public bool isDeath = false;
    public bool isAttack = false;
    public bool isIdle = true;

    public bool bulletspawn = true;
    public bool shootingrepeat = true;
    public bool PlayerIn = false;
    public bool isSkill = false;

    public int shootCount = 1;
    public int bulletsw = 1;
    public int bulletswSkill = 1;
    public int shooting = 1;
    public int SkillCount = 1;
    public int HpCrystal = 4;

    public bool Cinematic = true;

    float delay = 1f;

    public IceBossHp HpPoint;

    public Transform SpawnPos1;
    public Transform SpawnPos2;
    public GameObject IceSpikeSkill1;
    public GameObject IceSpikeWallSkill1;
    public GameObject IceSpikeSkill2;
    public GameObject InceBullet1;
    public GameObject InceBullet2;
    public GameObject IceBossHp;
    public GameObject IceBossHpText;
    public GameObject GameOver;
    public GameObject HealthCrystal2_1, HealthCrystal2_2;
    public GameObject SpikeWallEnd;
    public GameObject IceKey;

    public IceBossCinematic icebosscinematic;
    public GameObject Player;

    public GameObject BGMAudio;
    public GameObject BossAudioStage2;

    // Start is called before the first frame update
    void Start()
    {
        BGMAudio.SetActive(false);
        BossAudioStage2.SetActive(true);
        HpPoint.HpPoint = 200;
        SpikeWallEnd.SetActive(true);
        StartCoroutine(SpawnHealthCrystal());
    }

    // Update is called once per frame
    public void Update()
    {
        anime.SetBool("GetHit", isHit);
        anime.SetBool("Idle", isIdle);
        anime.SetBool("Attack", isAttack);

        if (BossHp <= 0 && isDeath == false)
        {
            isDeath = true;
            SpikeWallEnd.SetActive(false);
            Player.transform.position = new Vector3(107f, -17f, -2f);
            bulletspawn = false;
            icebosscinematic.gameObject.SetActive(true);
            icebosscinematic.CinematicStage4();
            HealthCrystal2_1.SetActive(false);
            HealthCrystal2_2.SetActive(false);
            StopCoroutine(SpawnHealthCrystal());
        }

        if (HpCrystal <= 0)
        {
            StopCoroutine(SpawnHealthCrystal());
        }
        StartCoroutine(BossSkill1());
    }

    public void Death()
    {
        isDeath = true;
        anime.SetBool("Death", isDeath);
        IceKey.SetActive(true);
        Destroy(this.gameObject, 1.5f);
        icebosscinematic.BeforeDeath();
    }

    IEnumerator SpawnHealthCrystal()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            HealthCrystal2_1.SetActive(true);
            yield return new WaitForSeconds(5f);
            HealthCrystal2_2.SetActive(true);
        }
    }

    IEnumerator BossSkill1()
    {
        if (BossHp <= 175 && SkillCount == 1)
        {
            isSkill = false;
            SkillCount++;
            IceSpikeSkill1.SetActive(true);
            yield return new WaitForSeconds(3f);
            isSkill = false;
            yield return new WaitForSeconds(0.5f);
            IceSpikeSkill1.SetActive(false);
        }
        if (BossHp <= 150 && SkillCount == 2)
        {
            isSkill = false;
            SkillCount++;
            IceSpikeWallSkill1.SetActive(true);
            yield return new WaitForSeconds(3f);
            isSkill = false;
            yield return new WaitForSeconds(0.5f);
            IceSpikeWallSkill1.SetActive(false);
        }
        if (BossHp <= 125 && SkillCount == 3)
        {
            isSkill = false;
            SkillCount++;
            IceSpikeSkill2.SetActive(true);
            yield return new WaitForSeconds(3f);
            isSkill = false;
            yield return new WaitForSeconds(0.5f);
            IceSpikeSkill2.SetActive(false);
        }
        if (BossHp <= 100 && SkillCount == 4)
        {
            isSkill = false;
            SkillCount++;
            IceSpikeWallSkill1.SetActive(true);
            yield return new WaitForSeconds(3f);
            isSkill = false;
            yield return new WaitForSeconds(0.5f);
            IceSpikeWallSkill1.SetActive(false);
        }
        if (BossHp <= 75 && SkillCount == 5)
        {
            isSkill = false;
            SkillCount++;
            IceSpikeSkill1.SetActive(true);
            yield return new WaitForSeconds(3f);
            isSkill = false;
            yield return new WaitForSeconds(0.5f);
            IceSpikeSkill1.SetActive(false);
        }
        if (BossHp <= 50 && SkillCount == 6)
        {
            isSkill = false;
            SkillCount++;
            IceSpikeSkill2.SetActive(true);
            yield return new WaitForSeconds(3f);
            isSkill = false;
            yield return new WaitForSeconds(0.5f);
            IceSpikeSkill2.SetActive(false);
        }
        if (BossHp <= 25 && SkillCount == 7)
        {
            isSkill = false;
            SkillCount++;
            IceSpikeSkill1.SetActive(true);
            yield return new WaitForSeconds(3f);
            isSkill = false;
            yield return new WaitForSeconds(0.5f);
            IceSpikeSkill1.SetActive(false);
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
