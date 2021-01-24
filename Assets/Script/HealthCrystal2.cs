using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCrystal2 : MonoBehaviour
{
    public Hp hpscript;
    public IceBossFinal icebossfinal;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DeSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.RotateAround(transform.position, Vector3.up, 70 * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            hpscript.HpCount(-35);
            this.gameObject.SetActive(false);
            StartCoroutine(DeSpawn());
            icebossfinal.HpCrystal--;
        }
    }

    IEnumerator DeSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            this.gameObject.SetActive(false);
        }
    }
}
