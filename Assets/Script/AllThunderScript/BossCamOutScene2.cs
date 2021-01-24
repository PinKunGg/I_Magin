using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCamOutScene2 : MonoBehaviour
{
    public Camera En_BossCam_Obj;
    public Camera Ds_BossCam_Obj;

    public GameObject ThunderBossHp;
    public GameObject ThunderHpText;

    public ThunderBossHp ThunderBossHpPoint;
    public ThunderBoss thunderboss;

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

            ThunderBossHp.gameObject.SetActive(false);
            ThunderHpText.gameObject.SetActive(false);

            if (ThunderBossHpPoint.HpPoint > 0)
            {
                ThunderBossHpPoint.HpPoint = 100;
                thunderboss.BossHp = 100;
                thunderboss.shooting = 0;
                thunderboss.shootCount = 1;
                thunderboss.bulletsw = 1;
                thunderboss.SkillNum = 1;
            }

            else
            {
                ThunderBossHpPoint.HpPoint = 0;
                thunderboss.BossHp = 0;

                BGMAudio.SetActive(true);
                BossAudio.SetActive(false);
            }
        }
    }
}
