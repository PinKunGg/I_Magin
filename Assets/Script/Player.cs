using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float m_moveSpeed = 4;
    public float m_jumpForce = 4;
    [SerializeField] private Animator m_animator;
    [SerializeField] private Rigidbody m_rigidBody;

    public float m_currentH = 0;
    public readonly float m_runScale = 4f;
    public bool m_isGrounded;
    public float jumpcount = 2;
    public int Turn = 1;
    public float m_walk = 0;
    public bool isWalk = false;
    public bool isRun = false;
    public bool isIdle = true;

    public float bulletReload = 5f;
    float OverTime = 0;
    float LockPlayer = 0;
    public bool TFBulletReload = false;
    public bool MNBulletReload = false;
    public bool ChangeCam = false;

    public bool esc = true;
    public bool isCinematic = false;
    public int sceneC = 1;

    public GameObject bullet;
    public Transform spawnPos;
    public Camera cam;
    public Camera Bosscam;
    public Hp HpPoint;
    public BulletReload bulletReloadScript;
    public GameObject GameOver;
    public GameObject Pause;

    void Start()
    {
        m_rigidBody = GetComponent<Rigidbody>();
        esc = true;
        Pause.SetActive(false);
        PausePlayer(false);
        Time.timeScale = 1;
        GameOver.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        DisCursor();
        GameOver.SetActive(false);
    }

    void Update()
    {
        m_animator.SetBool("Grounded", m_isGrounded);

        Controller1();

        CamMove();

        if (bulletReload <= 0 && TFBulletReload == false)
        {
            TFBulletReload = true;
            MNBulletReload = true;
            StartCoroutine(BulletReload());
        }

        if (MNBulletReload == true && bulletReload > 0)
        {
            bulletReload = 0;
            StartCoroutine(BulletReload());
        }
    }

    void DisCursor()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void PausePlayer(bool pause)
    {
        if (pause == true && esc == true)
        {
            Time.timeScale = 0;
            print("Pause-P");

            esc = false;
            Pause.SetActive(true);
        }

        else if (pause == false && esc == false)
        {
            Time.timeScale = 1;
            print("UnPause-P");

            esc = true;
            Pause.SetActive(false);
        }
    }

    private void Controller1()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isCinematic == false)
        {
            if (esc == false)
            {
                PausePlayer(false);
            }

            else if (esc == true)
            {
                PausePlayer(true);
            }
        }

        if (esc == true && isCinematic == false)
        {

            //======================================================[TURN]================================================================

            if (Input.GetKeyDown(KeyCode.D) && Turn == 0)
            {
                Turn = 1;
                transform.Rotate(0, 180, 0);
            }
            else if (Input.GetKeyDown(KeyCode.A) && Turn == 1)
            {
                Turn = 0;
                transform.Rotate(0, 180, 0);
            }

            //======================================================[WALK]================================================================

            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.forward * m_moveSpeed * Time.deltaTime);
                isIdle = false;

                if (isRun == false)
                {
                    m_walk = 1;
                    isWalk = true;
                }
                if (isRun == true)
                {
                    m_walk = 0;
                }
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.forward * m_moveSpeed * Time.deltaTime);
                isIdle = false;

                if (isRun == false)
                {
                    m_walk = 1;
                    isWalk = true;
                }
                if (isRun == true)
                {
                    m_walk = 0;
                }
            }

            //=================================================[STOP-WALK]================================================================

            else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
            {
                m_walk = 0;
                isIdle = true;
                isWalk = false;
            }

            //=====================================================[RUN]==================================================================

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                m_moveSpeed = m_moveSpeed + m_runScale;
            }

            if (Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
            {
                if (isWalk == true)
                {
                    isRun = true;
                    isIdle = false;
                    m_currentH = 1;
                    m_walk = 0;
                }
            }

            //=====================================================[STOP-RUN]===============================================================

            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                isIdle = true;
                isRun = false;
                m_currentH = 0;
                m_moveSpeed = 4;
            }

            //===================================================[STOP-ALL]================================================================

            if (Input.GetKeyUp(KeyCode.LeftShift) || (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)))
            {
                isIdle = true;
                isRun = false;
                isWalk = false;
                m_walk = 0;
                m_currentH = 0;
            }

            //======================================================[SHOOT]================================================================

            if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Q)) && bulletReload > 0 && TFBulletReload == false)
            {
                FireBullet();

                bulletReloadScript.BulletText();

                bulletReload--;
            }
            if (Input.GetKeyDown(KeyCode.R) && bulletReload > 0 && MNBulletReload == false)
            {

                MNBulletReload = true;

                bulletReloadScript.BulletTextReload();
            }

            //============================================================================================================================

            JumpingAndLanding();
        }

        m_animator.SetFloat("MoveSpeed", m_currentH);
        m_animator.SetFloat("Walk", m_walk);
        m_animator.SetBool("Idle", isIdle);
    }

    private void JumpingAndLanding()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpcount >= 1)
        {
            m_rigidBody.AddForce(Vector3.up * m_jumpForce, ForceMode.Impulse);

            print("JUMP!!!");

            jumpcount--;
        }

        if (jumpcount == 0)
        {
            m_rigidBody.AddForce(0, 0, 0, ForceMode.Impulse);
        }

        if (m_isGrounded == true)
        {
            m_animator.SetTrigger("Land");
        }

        if (m_isGrounded == false)
        {
            m_animator.SetTrigger("Jump");
        }
    }

    IEnumerator BulletReload()
    {
        yield return new WaitForSeconds(2);

        bulletReloadScript.bulletCount = 5f;
        bulletReload = 5f;
        TFBulletReload = false;
        MNBulletReload = false;
    }

    void FireBullet()
    {
        Instantiate(bullet, spawnPos.position, spawnPos.rotation);
    }

    public void CamMove()
    {
        if (ChangeCam == false)
        {
            if (sceneC == 1)
            {
                cam.transform.position = new Vector3(this.transform.position.x + 1f, this.transform.position.y + 2f, this.transform.position.z - 8f);
                print("Cam Boss 1");
                Bosscam.transform.position = new Vector3(this.transform.position.x + 8f, this.transform.position.y + 3f, this.transform.position.z - 12f);
            }
            if (sceneC == 2)
            {
                cam.transform.position = new Vector3(this.transform.position.x + 1f, this.transform.position.y + 3f, this.transform.position.z - 9f);
                print("Cam Boss 2");
                Bosscam.transform.position = new Vector3(this.transform.position.x + 8f, this.transform.position.y + 3f, this.transform.position.z - 18f);
            }
            if (sceneC == 3)
            {
                cam.transform.position = new Vector3(this.transform.position.x + 1f, this.transform.position.y + 3f, this.transform.position.z - 10f);
                print("IceCaveCam");
                Bosscam.transform.position = new Vector3(this.transform.position.x + 1f, this.transform.position.y + 4f, this.transform.position.z - 15f);
            }
            if (sceneC == 4)
            {
                cam.transform.position = new Vector3(this.transform.position.x + 1f, this.transform.position.y + 2f, this.transform.position.z - 6f);
                print("FinalStage");
                Bosscam.transform.position = new Vector3(this.transform.position.x + 4f, this.transform.position.y + 4f, this.transform.position.z - 11f);
            }
            if (sceneC == 5)
            {
                Bosscam.transform.position = new Vector3(this.transform.position.x + 1, this.transform.position.y + 4f, this.transform.position.z - 20f);
                //Bosscam.transform.position = new Vector3(this.transform.position.x - 3f, this.transform.position.y + 3f, this.transform.position.z - 10f);
                //Bosscam.transform.rotation = Quaternion.Euler(-5f, 15f, 0f);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Rock")
        {
            m_isGrounded = true;
            jumpcount = 2;

            print("Floor = " + jumpcount);
        }

        if (collision.gameObject.tag == "Bullet")
        {
            HpPoint.HpCount(2);
        }

        if (collision.gameObject.tag == "BossBullet")
        {
            HpPoint.HpCount(5);
        }

        if (collision.gameObject.tag == "BossSkill1")
        {
            HpPoint.HpCount(15);
        }
        if (collision.gameObject.tag == "BossSkill2")
        {
            HpPoint.HpCount(10);
        }

        if (collision.gameObject.tag == "TrapRock")
        {
            GameOver.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Rock")
        {
            m_isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Rock")
        {
            m_isGrounded = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            HpPoint.HpCount(2);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "BossBullet")
        {
            HpPoint.HpCount(5);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "BossSkill1")
        {
            HpPoint.HpCount(15);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "BossSkill2")
        {
            HpPoint.HpCount(3);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "BossSkill3")
        {
            HpPoint.HpCount(10);
            OverTime = 0;
        }
        if (other.gameObject.tag == "BossSkill4")
        {
            HpPoint.HpCount(15);
            LockPlayer = 0;
        }
        if (other.gameObject.tag == "BossSkill5")
        {
            HpPoint.HpCount(3);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "BossSkill3")
        {
            OverTime = 3;
            StopCoroutine(DamageOverTime());
            StopCoroutine(StopDmgOverTime());
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if ((other.gameObject.tag == "BossSkill3") && OverTime == 0)
        {
            OverTime = 1;
            StartCoroutine(DamageOverTime());
        }

        if(other.gameObject.tag == "BossSkill4" && LockPlayer == 0)
        {
            LockPlayer = 1;
            StartCoroutine(LockStatus());
        }
    }

    IEnumerator LockStatus()
    {
        m_moveSpeed = 0;
        jumpcount = 0;
        yield return new WaitForSeconds(1f);
        DisLockStatus();
    }

    void DisLockStatus()
    {
        StopCoroutine(LockStatus());
        m_moveSpeed = 4;
        jumpcount = 2;
        LockPlayer = 0;
    }

    IEnumerator DamageOverTime()
    {
        while (OverTime == 1)
        {
            OverTime = 2;
            HpPoint.HpCount(5);
            StartCoroutine(StopDmgOverTime());
        }
        yield return null;
    }

    IEnumerator StopDmgOverTime()
    {
        if (OverTime == 2)
        {
            StopCoroutine(DamageOverTime());
            yield return new WaitForSeconds(0.3f);
            OverTime = 0;
            StartCoroutine(DamageOverTime());
        }
    }
}
