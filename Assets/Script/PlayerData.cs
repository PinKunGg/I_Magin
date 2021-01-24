using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float jumpcount;
    public int Turn;

    public float bulletReload;
    public bool TFBulletReload;
    public bool MNBulletReload;

    public bool esc;
    public int sceneC;

    public int HpPoint;
    public float bulletCount;
    public float[] position;
    public float[] rotation;

    public PlayerData (Player player, Hp HpPointS, BulletReload bulletReloadS)
    {
        jumpcount = player.jumpcount;
        Turn = player.Turn;
        bulletReload = player.bulletReload;
        TFBulletReload = player.TFBulletReload;
        MNBulletReload = player.MNBulletReload;
        esc = player.esc;
        sceneC = player.sceneC;
        HpPoint = HpPointS.HpPoint;
        bulletCount = bulletReloadS.bulletCount;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

        rotation = new float[3];
        rotation[0] = player.transform.rotation.x;
        rotation[1] = player.transform.rotation.y;
        rotation[2] = player.transform.rotation.z;
    }

}
