using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagementScene2 : MonoBehaviour
{
    public ThunderWarp thunderwarp;
    public Player playerscript;
    public GameObject canvas;
    public GameObject canvas2;
    public GameObject Bridge;
    public GameObject KeyHint;

    // Start is called before the first frame update
    void Start()
    {
        Bridge.SetActive(false);
        canvas.SetActive(true);
        canvas2.SetActive(true);
        KeyHint.SetActive(false);

        playerscript.sceneC = 2;

        thunderwarp.thunderkeyscore = 0;
        playerscript.esc = true;
        playerscript.PausePlayer(false);

        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BossDeath()
    {
        Invoke("KeyHintOn", 1f);
    }

    void KeyHintOn()
    {
        KeyHint.SetActive(true);
    }
}
