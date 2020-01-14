using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMgr : MonoBehaviour
{
    public static PlayerMgr playermgr;

    // Start is called before the first frame update
    void Start()
    {
        playermgr = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Transform SettingPlayerTrandform()
    {
        return GameObject.FindWithTag("player").transform;
    }
}
