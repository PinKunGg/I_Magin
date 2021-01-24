using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagementScene1 : MonoBehaviour
{
    public WindWarp windwarp;
    public Player playerscript;
    public Hp HpPointS;
    public BulletReload bulletReloadS;
    public GameObject KeyHint;

    public GameObject canvas;
    public GameObject canvas2;

    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(true);
        canvas2.SetActive(true);

        playerscript.sceneC = 1;

        windwarp.windkeyscore = 0;
        playerscript.esc = true;
        playerscript.PausePlayer(false);
        KeyHint.SetActive(false);

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

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(playerscript, HpPointS, bulletReloadS);

        playerscript.esc = false;
        playerscript.PausePlayer(false);
        print("Saved To" +Application.persistentDataPath);
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        playerscript.jumpcount = data.jumpcount;
        playerscript.Turn = data.Turn;
        playerscript.bulletReload = data.bulletReload;
        playerscript.TFBulletReload = data.TFBulletReload;
        playerscript.MNBulletReload = data.MNBulletReload;
        playerscript.esc = data.esc;
        playerscript.sceneC = data.sceneC;
        HpPointS.HpPoint = data.HpPoint;
        bulletReloadS.bulletCount = data.bulletCount;

        Vector3 position;
        Vector3 rotation/* = new Vector3 (data.rotation[0], data.rotation[1], data.rotation[2])*/;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];

        rotation.x = data.rotation[0];
        rotation.y = data.rotation[1];
        rotation.z = data.rotation[2];
        playerscript.transform.position = position;

        if (data.rotation[1] > 0)
        {
            rotation.y = 90;
            playerscript.transform.rotation = Quaternion.Euler(rotation);
        }
        if (data.rotation[1] < 0)
        {
            rotation.y = -90;
            playerscript.transform.rotation = Quaternion.Euler(rotation);
        }

        playerscript.esc = false;
        playerscript.PausePlayer(false);
        print("Loaded From" +Application.persistentDataPath);
    }
}
