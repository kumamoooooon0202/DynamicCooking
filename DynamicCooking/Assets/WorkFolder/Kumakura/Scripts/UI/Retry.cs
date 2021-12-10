using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    private bool trigger = false;

    public void TapRetry()
    {
        if (trigger) { return; }
        trigger = true;
        FadeControl.Instance.Fade("out", ()=>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            FlagManager.Instance.SetFlagState(FlagName.Push, false);
            FlagManager.Instance.SetFlagState(FlagName.RotationFlag, true);
            FadeControl.Instance.Fade("in", ()=> trigger = false);
        });
    }
}
