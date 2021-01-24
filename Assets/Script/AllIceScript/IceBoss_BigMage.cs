using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IceBoss_BigMage : MonoBehaviour
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
    bool firstrun = true;

    int shootCount = 1;
    int bulletsw = 1;
    int SkillCount = 1;
    public int SkillSet = 0;

    public bool Cinematic = true;

    float delay = 1f;

    public IceBossHp HpPoint;

    public Transform SkillVer1, SkillVer2, SkillVer3, SkillVer4, SkillVer5, SkillVer6;
    public GameObject MonSpawn1, MonSpawn2, MonSpawn3, MonSpawn4, MonSpawn5, MonSpawn6, MonSpawn7;
    public GameObject IceSpikeSkill1;
    public GameObject SummonIceBoss;
    public GameObject IceBossIceSpike;
    public GameObject InceBulletVer;
    public GameObject IceBossHp;
    public GameObject IceBossHpText;
    public GameObject GameOver;
    public GameObject HealthCrystal;
    public GameObject Player;

    public GameObject WindBoss;
    public GameObject ThunderBoss;
    public GameObject IceBossCinematic;
    public IceBossCinematic IceBossCinematicS;

    public GameObject BGMAudio;
    public GameObject BossAudioStage1;

    // Start is called before the first frame update
    void Start()
    {
        BGMAudio.SetActive(false);
        BossAudioStage1.SetActive(true);
        IceBossHp.SetActive(false);
        IceBossHpText.SetActive(false);
        StartCoroutine(IceSkill1());
        Invoke("MonSpawnSkill1", 5f);
    }

    // Update is called once per frame
    public void Update()
    {
        anime.SetBool("GetHit", isHit);
        anime.SetBool("Idle", isIdle);
        anime.SetBool("Attack", isAttack);

        //===============================================================================

        print(SkillSet);

        if (SkillSet >= 7 && firstrun == true)
        {
            firstrun = false;
            Invoke("IceSpike1", 2f);
        }

        //===============================================================================

        if (SkillSet >= 9)
        {
            BGMAudio.SetActive(true);
            BossAudioStage1.SetActive(false);
            IceBossCinematic.SetActive(true);
            IceBossCinematicS.CinematicStage3();
            Player.transform.position = new Vector3(107f, -17f, -2f);
        }
    }

    void StopAnimate()
    {
        isHit = false;
        isDeath = false;
    }

    void TriggerStopAnimate()
    {
        isAttack = false;
        isIdle = true;
    }

    IEnumerator CheckIceSkill1()
    {
        while (true)
        {
            //===============================================================================
            if (shootCount >= 1 && shootCount <= 1 && bulletsw == 1)
            {
                bulletspawn = true;
            }
            if (shootCount > 1 && bulletsw == 1)
            {
                bulletsw = 2;
                shootCount = 1;
            }
            //===============================================================================
            if (shootCount >= 1 && shootCount <= 1 && bulletsw == 2)
            {
                bulletspawn = true;
            }
            if (shootCount > 1 && bulletsw == 2)
            {
                bulletsw = 3;
                shootCount = 1;
            }
            //===============================================================================
            if (shootCount >= 1 && shootCount <= 1 && bulletsw == 3)
            {
                bulletspawn = true;
            }
            if (shootCount > 1 && bulletsw == 3)
            {
                bulletsw = 4;
                shootCount = 1;
            }
            //===============================================================================
            if (shootCount >= 1 && shootCount <= 1 && bulletsw == 4)
            {
                bulletspawn = true;
            }
            if (shootCount > 1 && bulletsw == 4)
            {
                bulletsw = 5;
                shootCount = 1;
            }
            //===============================================================================
            if (shootCount >= 1 && shootCount <= 1 && bulletsw == 5)
            {
                bulletspawn = true;
            }
            if (shootCount > 1 && bulletsw == 5)
            {
                bulletsw = 6;
                shootCount = 1;
            }
            //===============================================================================
            if (shootCount >= 1 && shootCount <= 1 && bulletsw == 6)
            {
                bulletspawn = true;
            }
            if (shootCount > 1 && bulletsw == 6)
            {
                bulletsw = 7;
                shootCount = 1;
            }
            //===============================================================================
            if (shootCount >= 1 && shootCount <= 15 && bulletsw == 7)
            {
                bulletspawn = true;
            }
            if (shootCount > 15 && bulletsw == 7)
            {
                bulletsw = 8;
                shootCount = 1;
            }
            //===============================================================================
            yield return null;
        }
    }

    private IEnumerator IceSkill1()
    {
        StartCoroutine(CheckIceSkill1());

        while (true)
        {
            yield return new WaitForSeconds(0.7f);
            //===============================================================================
            if (bulletspawn == true && bulletsw == 1)
            {
                Instantiate(InceBulletVer, SkillVer1.position, SkillVer1.rotation);
                shootCount += 1;
                Invoke("TriggerStopAnimate", 1.2f);
            }
            //===============================================================================
            if (bulletspawn == true && bulletsw == 2)
            {
                Instantiate(InceBulletVer, SkillVer2.position, SkillVer2.rotation);
                shootCount += 1;
                Invoke("TriggerStopAnimate", 1.2f);
            }
            //===============================================================================
            if (bulletspawn == true && bulletsw == 3)
            {
                Instantiate(InceBulletVer, SkillVer3.position, SkillVer3.rotation);
                shootCount += 1;
                Invoke("TriggerStopAnimate", 1.2f);
            }
            //===============================================================================
            if (bulletspawn == true && bulletsw == 4)
            {
                Instantiate(InceBulletVer, SkillVer4.position, SkillVer4.rotation);
                shootCount += 1;
                Invoke("TriggerStopAnimate", 1.2f);
            }
            //===============================================================================
            if (bulletspawn == true && bulletsw == 5)
            {
                Instantiate(InceBulletVer, SkillVer5.position, SkillVer5.rotation);
                shootCount += 1;
                Invoke("TriggerStopAnimate", 1.2f);
            }
            //===============================================================================
            if (bulletspawn == true && bulletsw == 6)
            {
                Instantiate(InceBulletVer, SkillVer6.position, SkillVer6.rotation);
                shootCount += 1;
                Invoke("TriggerStopAnimate", 1.2f);
            }
            //===============================================================================
            if (bulletspawn == true && bulletsw == 7)
            {
                Instantiate(InceBulletVer, SkillVer1.position, SkillVer1.rotation);
                Instantiate(InceBulletVer, SkillVer2.position, SkillVer2.rotation);
                Instantiate(InceBulletVer, SkillVer3.position, SkillVer3.rotation);
                Instantiate(InceBulletVer, SkillVer4.position, SkillVer4.rotation);
                Instantiate(InceBulletVer, SkillVer5.position, SkillVer5.rotation);
                Instantiate(InceBulletVer, SkillVer6.position, SkillVer6.rotation);
                shootCount += 1;
                Invoke("TriggerStopAnimate", 1.2f);
            }
            //===============================================================================
        }
    }

    void MonSpawnSkill1()
    {
        MonSpawn1.SetActive(true);
        MonSpawn2.SetActive(true);
        MonSpawn3.SetActive(true);
        MonSpawn4.SetActive(true);
        MonSpawn5.SetActive(true);
        MonSpawn6.SetActive(true);
        MonSpawn7.SetActive(true);
    }

    void IceSpike1()
    {
        IceSpikeSkill1.SetActive(true);
        Invoke("DisIceSpike1",4f);
    }
    void DisIceSpike1()
    {
        IceSpikeSkill1.SetActive(false);
        Invoke("SummonIceBossSkill", 4f);
    }

    void SpawnHealthCrysyal()
    {
        HealthCrystal.SetActive(true);
    }

    void SummonIceBossSkill()
    {
        SummonIceBoss.SetActive(true);
        Invoke("IceBossIceSpikeSkill", 2f);
    }

    void IceBossIceSpikeSkill()
    {
        IceBossIceSpike.SetActive(true);
        Invoke("SpawnHealthCrysyal", 1f);
        Invoke("DisSummonIceBossSpike", 4f);
    }

    void DisSummonIceBossSpike()
    {
        SummonIceBoss.SetActive(false);
        IceBossIceSpike.SetActive(false);
        Invoke("SummonWindandThunderBoss", 4f);
    }

    void SummonWindandThunderBoss()
    {
        WindBoss.SetActive(true);
        ThunderBoss.SetActive(true);
    }
}
