using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagGenerator : MonoBehaviour
{
    void Start()
    {
        for (int flag = 0; flag < (int)FlagName.FlagEnd; flag++)
        {
            FlagManager.Instance.SetFlagState((FlagName)flag, false);
        }
    }
}
