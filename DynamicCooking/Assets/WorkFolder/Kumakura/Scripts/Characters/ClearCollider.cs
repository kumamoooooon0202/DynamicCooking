using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCollider : MonoBehaviour
{
    [SerializeField] private PlayerControl playerControl;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Goal")
        {
            FlagManager.Instance.SetFlagState(FlagName.GameStart, false);
            playerControl.ImageNotView();
            playerControl.sushiImage.enabled = true;
            FlagManager.Instance.SetFlagState(FlagName.RotationFlag, true);
        }
    }
}
