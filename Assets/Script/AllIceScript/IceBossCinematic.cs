using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBossCinematic : MonoBehaviour
{
    public GameObject IceBossText;
    public GameObject IceBossDialog1;
    public GameObject IceBossDialog2;
    public GameObject IceBossDialog3;
    public GameObject IceBossDialog4;
    public GameObject ContinueBut1;
    public GameObject ContinueBut2;
    public GameObject ContinueBut3;
    public GameObject ContinueBut4;
    public GameObject Cinematic;
    public GameObject canvas1;
    public GameObject IceMage1;
    public GameObject IceMage2;
    public GameObject IceMage3;
    public Camera CinematicCam1;
    public Camera BossCam;
    public GameObject IceMage_UI;
    public GameObject IceMage_HP;
    public GameObject FightArea;

    public GameObject SpikeWall;

    public Player playerscript;
    public IceBoss iceBoss;
    public IceBossFinal iceBossF;
    public Hp hp;

    bool firstCinematic = true;

    // Start is called before the first frame update
    void Start()
    {
        SpikeWall.SetActive(false);
        IceBossText.SetActive(false);
        IceBossDialog1.SetActive(false);
        ContinueBut1.SetActive(false);
        ContinueBut2.SetActive(false);
        ContinueBut3.SetActive(false);
        ContinueBut4.SetActive(false);
        Cinematic.SetActive(false);
        IceMage_UI.SetActive(false);
        IceMage_HP.SetActive(false);
        FightArea.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CinematicStage2()
    {
        iceBoss.Cinematic = true;
        FightArea.SetActive(false);
        canvas1.SetActive(false);
        IceBossText.SetActive(true);
        Cinematic.SetActive(true);
        IceBossDialog2.SetActive(true);
        playerscript.esc = false;
        playerscript.isWalk = false;
        playerscript.isRun = false;
        playerscript.isIdle = true;
        playerscript.m_currentH = 0;
        playerscript.m_walk = 0;
        playerscript.m_moveSpeed = 4;
        playerscript.isCinematic = true;
    }

    public void CinematicStage3()
    {
        IceMage2.SetActive(false);
        IceMage1.SetActive(true);
        iceBoss.Cinematic = true;
        FightArea.SetActive(false);
        canvas1.SetActive(false);
        IceBossText.SetActive(true);
        Cinematic.SetActive(true);
        playerscript.sceneC = 4;
        IceBossDialog3.SetActive(true);
        playerscript.esc = false;
        playerscript.isWalk = false;
        playerscript.isRun = false;
        playerscript.isIdle = true;
        playerscript.m_currentH = 0;
        playerscript.m_walk = 0;
        playerscript.m_moveSpeed = 4;
        playerscript.isCinematic = true;
    }

    public void CinematicStage4()
    {
        iceBossF.Cinematic = true;
        FightArea.SetActive(false);
        canvas1.SetActive(false);
        IceBossText.SetActive(true);
        Cinematic.SetActive(true);
        playerscript.sceneC = 4;
        IceBossDialog4.SetActive(true);
        playerscript.esc = false;
        playerscript.isWalk = false;
        playerscript.isRun = false;
        playerscript.isIdle = true;
        playerscript.m_currentH = 0;
        playerscript.m_walk = 0;
        playerscript.m_moveSpeed = 4;
        playerscript.isCinematic = true;
    }

    public void BeforeDeath()
    {
        Invoke("Ending", 2f);
    }

    public void Ending()
    {
        Cinematic.SetActive(false);
        canvas1.SetActive(true);
        IceMage_UI.SetActive(false);
        IceMage_HP.SetActive(false);
        playerscript.esc = true;
        playerscript.isCinematic = false;
        iceBossF.Cinematic = false;
        gameObject.SetActive(false);
    }

    public void BeforeMagePurple()
    {
        Invoke("IceMagePurple", 1f);
    }

    public void IceMagePurple()
    {
        IceMage1.SetActive(false);
        IceMage3.SetActive(true);
        Invoke("DisCinematicStage3", 1f);
    }

    public void DisCinematicStage3()
    {
        Cinematic.SetActive(false);
        canvas1.SetActive(true);
        IceMage_UI.SetActive(true);
        IceMage_HP.SetActive(true);
        playerscript.esc = true;
        playerscript.isCinematic = false;
        iceBossF.Cinematic = false;
        gameObject.SetActive(false);
        hp.HpPoint = 100;
    }

    public void DisCinematic()
    {
        IceBossText.SetActive(false);
        IceBossDialog1.SetActive(false);
        ContinueBut1.SetActive(false);
        ContinueBut2.SetActive(false);
        gameObject.SetActive(false);
        Cinematic.SetActive(false);
        canvas1.SetActive(true);
        playerscript.esc = true;
        playerscript.isCinematic = false;
        IceMage_UI.SetActive(true);
        IceMage_HP.SetActive(true);
        iceBoss.Cinematic = false;
    }

    public void DisCinematic1()
    {
        CinematicCam1.gameObject.SetActive(false);
        BossCam.gameObject.SetActive(true);
        IceBossText.SetActive(false);
        IceBossDialog2.SetActive(false);
        ContinueBut1.SetActive(false);
        ContinueBut2.SetActive(false);
        playerscript.sceneC = 5;
        gameObject.SetActive(false);
        Invoke("BigIceMage", 1f);
    }

    void BigIceMage()
    {
        IceMage1.SetActive(false);
        IceMage2.SetActive(true);
        Invoke("DisCinematic2", 1f);
    }

    void DisCinematic2()
    {
        Cinematic.SetActive(false);
        canvas1.SetActive(true);
        gameObject.SetActive(false);
        playerscript.esc = true;
        playerscript.isCinematic = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && firstCinematic == true)
        {
            firstCinematic = false;
            SpikeWall.SetActive(true);
            FightArea.SetActive(true);
            canvas1.SetActive(false);
            IceBossText.SetActive(true);
            Cinematic.SetActive(true);
            IceBossDialog1.SetActive(true);
            CinematicCam1.gameObject.SetActive(true);
            BossCam.gameObject.SetActive(false);
            playerscript.esc = false;
            playerscript.isWalk = false;
            playerscript.isRun = false;
            playerscript.isIdle = true;
            playerscript.m_currentH = 0;
            playerscript.m_walk = 0;
            playerscript.m_moveSpeed = 4;
            playerscript.isCinematic = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            IceBossText.SetActive(true);
            Cinematic.SetActive(true);
            IceBossDialog1.SetActive(true);
        }
    }
}
