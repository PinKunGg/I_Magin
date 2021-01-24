using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCamInScene2 : MonoBehaviour
{
    public Camera En_BossCam_Obj;
    public Camera Ds_BossCam_Obj;

    public ThunderBossHp ThunderBossHp;
    public Player player;
    public GameObject ThunderBossHpText;

    public GameObject BossAudio;
    public GameObject BGMAudio;

    // Start is called before the first frame update
    void Start()
    {
        ActiveBar(false);
        ThunderBossHp.gameObject.SetActive(false);
        ThunderBossHpText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            BGMAudio.SetActive(false);
            BossAudio.SetActive(true);

            Ds_BossCam_Obj.gameObject.SetActive(false);

            En_BossCam_Obj.gameObject.SetActive(true);

            if (ThunderBossHp.HpPoint > 0)
            {
                ActiveBar(true);
                BGMAudio.SetActive(false);
                BossAudio.SetActive(true);
            }
            if (ThunderBossHp.HpPoint <= 0)
            {
                ActiveBar(false);
                BGMAudio.SetActive(true);
                BossAudio.SetActive(false);
            }
        }
    }

    public void ActiveBar(bool isActiveBar)
    {
        if (isActiveBar)
        {
            ThunderBossHp.gameObject.SetActive(isActiveBar);
            ThunderBossHpText.gameObject.SetActive(isActiveBar);
        }
    }
}
