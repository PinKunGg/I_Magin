using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire_3 : MonoBehaviour
{
    float speed = 20f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Bullet" && collision.gameObject.tag != "BossBullet" && collision.gameObject.tag != "PlayerBullet" && collision.gameObject.tag != "BossSkill1" && collision.gameObject.tag != "BossSkill2" && collision.gameObject.tag != "BossSkill3" && collision.gameObject.tag != "BossSkill4")
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Destroy")
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Destroy")
        {
            Destroy(this.gameObject);
        }
    }
}
