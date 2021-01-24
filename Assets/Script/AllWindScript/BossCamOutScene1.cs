using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCamOutScene1 : MonoBehaviour
{
    public Camera En_BossCam_Obj;
    public Camera Ds_BossCam_Obj;

    public GameObject WindBossHp;
    public GameObject WindBossHpText;

    public WindBossHp WindBossHpPoint;
    public WindBoss windboss;

    public GameObject BossAudio;
    public GameObject BGMAudio;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            BGMAudio.SetActive(true);
            BossAudio.SetActive(false);

            Ds_BossCam_Obj.gameObject.SetActive(false);

            En_BossCam_Obj.gameObject.SetActive(true);

            WindBossHp.gameObject.SetActive(false);
            WindBossHpText.gameObject.SetActive(false);

            if (WindBossHpPoint.HpPoint > 0)
            {
                WindBossHpPoint.HpPoint = 100;
                windboss.BossHp = 100;
                windboss.shooting = 0;
                windboss.shootCount = 1;
                windboss.bulletsw = 1;
                windboss.SkillNum = 1;
            }

            else
            {
                BGMAudio.SetActive(true);
                BossAudio.SetActive(false);

                WindBossHpPoint.HpPoint = 0;
                windboss.BossHp = 0;
            }
        }
    }
}
