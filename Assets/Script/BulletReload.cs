using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletReload : MonoBehaviour
{
    public TextMeshProUGUI bulletReload;
    public float bulletCount;

    // Start is called before the first frame update
    void Start()
    {
        bulletReload = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bulletCount <= 0)
        {
            bulletReload.text = "Bullet: Reloading...";
        }

        else
        {
            bulletReload.text = "Bullet: " + bulletCount;
        }
    }

    public void BulletText()
    {
        bulletCount--;
    }

    public void BulletTextReload()
    {
        bulletCount = 0;
    }
}
