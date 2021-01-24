using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapCode : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RotateGunS(this.transform.position.x, this.transform.position.z, player.transform.position.x, player.transform.position.z);
    }

    void RotateGunS(float selfx, float selfz, float playerx, float playerz)
    {
        float r2d = 57.29578f;
        float theta = r2d * Mathf.Atan2(playerx - selfx, playerz - selfz);
        this.transform.rotation = Quaternion.Euler(0f, theta, 0f);
    }
}
