using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerControl player;


    void Start()
    {
        player = FindObjectOfType<PlayerControl>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && 
            FlagManager.Instance.GetFlagState(FlagName.GameStart) && 
            FlagManager.Instance.GetFlagState(FlagName.Push) == false)
        {
            FlagManager.Instance.SetFlagState(FlagName.Push, true);
            player.body.AddForce(player.transform.forward * 1.5f, ForceMode.Impulse);
        }
    }
}
