using UnityEngine;
using System.Collections.Generic;
using System;

public class SimpleCharacterControl : MonoBehaviour
{

    private enum ControlMode
    {
        Controller1
    }

    [SerializeField] private float m_moveSpeed = 2;
    [SerializeField] private float m_turnSpeed = 200;
    [SerializeField] private float m_jumpForce = 25;
    [SerializeField] private Animator m_animator;
    [SerializeField] private Rigidbody m_rigidBody;

    [SerializeField] private ControlMode m_controlMode = ControlMode.Controller1;

    private float m_currentV = 0;
    private float m_currentH = 0;

    private readonly float m_interpolation = 10;
    private readonly float m_walkScale = 0.33f;
    private readonly float m_runScale = 4f;
    private readonly float m_BackwardRunScale = 1.7f;
    private readonly float m_backwardsWalkScale = 0.16f;
    private readonly float m_backwardRunScale = 0.66f;

    private bool m_wasGrounded;
    private Vector3 m_currentDirection = Vector3.zero;

    private float m_jumpTimeStamp = 0;
    private float m_minJumpInterval = 0.25f;

    private bool m_isGrounded;
    private List<Collider> m_collisions = new List<Collider>();

    private float jumpcount = 2;
    private float thrust = 0;
    public GameObject bullet;
    public Transform spawnPos;
    private int Turn = 1;

    public Camera cam;
    public Hp HpPoint;

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint[] contactPoints = collision.contacts;
        for (int i = 0; i < contactPoints.Length; i++)
        {
            if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
            {
                if (!m_collisions.Contains(collision.collider))
                {
                    m_collisions.Add(collision.collider);
                }
                m_isGrounded = true;
            }
        }

        //======================================================

        if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Rock")
        {
            jumpcount = 2;

            print("Floor = " + jumpcount);
        }

        if (collision.gameObject.tag == "Bullet")
        {
            HpPoint.HpCount(10);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        ContactPoint[] contactPoints = collision.contacts;
        bool validSurfaceNormal = false;
        for (int i = 0; i < contactPoints.Length; i++)
        {
            if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
            {
                validSurfaceNormal = true; break;
            }
        }

        if (validSurfaceNormal)
        {
            m_isGrounded = true;
            if (!m_collisions.Contains(collision.collider))
            {
                m_collisions.Add(collision.collider);
            }
        }
        else
        {
            if (m_collisions.Contains(collision.collider))
            {
                m_collisions.Remove(collision.collider);
            }
            if (m_collisions.Count == 0) { m_isGrounded = false; }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (m_collisions.Contains(collision.collider))
        {
            m_collisions.Remove(collision.collider);
        }
        if (m_collisions.Count == 0) { m_isGrounded = false; }
    }

    void Start()
    {
        m_rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        m_animator.SetBool("Grounded", m_isGrounded);

        switch (m_controlMode)
        {
            case ControlMode.Controller1:
                Controller1();
                break;

            default:
                Debug.LogError("Unsupported state");
                break;
        }

        m_wasGrounded = m_isGrounded;

        FireBullet();

        CamMove();
    }

    private void Controller1()
    {
        if (Input.GetKeyDown(KeyCode.D) && Turn == 0)
        {
            transform.Rotate(0, 180, 0);
            Turn = 1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.forward * m_moveSpeed * Time.deltaTime);
            m_currentH += 1;
        }
        else if (Input.GetKeyDown(KeyCode.A) && Turn == 1)
        {
            transform.Rotate(0, 180, 0);
            Turn = 0;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.forward * m_moveSpeed * Time.deltaTime);
            m_currentH += 1;
        }
        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            m_currentH = 0;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            m_moveSpeed = m_moveSpeed + m_runScale;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            m_moveSpeed = m_moveSpeed - m_runScale;
        }

        m_animator.SetFloat("MoveSpeed", m_currentH);

        JumpingAndLanding();
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
            m_rigidBody.AddForce(0, 0, thrust, ForceMode.Impulse);
        }

        if (!m_wasGrounded && m_isGrounded)
        {
            m_animator.SetTrigger("Land");
        }

        if (!m_isGrounded && m_wasGrounded)
        {
            m_animator.SetTrigger("Jump");
        }
    }

    void FireBullet()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, spawnPos.position, spawnPos.rotation);
        }
    }

    void CamMove()
    {
        cam.transform.position = new Vector3(this.transform.position.x + 2f, this.transform.position.y + 2f, this.transform.position.z - 6f);
    }
}
