using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    public GameObject BGMAudio;
    public GameObject BossAudio;
    public GameObject BossAudio2;

    // Start is called before the first frame update
    void Start()
    {
        BGMAudio.SetActive(false);
        BossAudio.SetActive(false);
        BossAudio2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
