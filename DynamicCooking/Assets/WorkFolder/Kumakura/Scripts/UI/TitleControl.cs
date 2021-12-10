using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleControl : MonoBehaviour
{

    private float time;
    [SerializeField] private Image tapImage;
    [SerializeField, Header("点滅間隔")] private float interval;
    [SerializeField, Header("触れ幅")] private float pulse;
    [SerializeField, Header("触れ幅の初期値")] private float initValPalse;

    private bool fadeFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tapImage.color = ColorChange(tapImage.color);
        if (Input.GetMouseButtonDown(0) && fadeFlag == false)
        {
            fadeFlag = true;
            FadeControl.Instance.Fade("out", () =>
            {
                SceneManager.LoadScene("Main_Stage");
                FadeControl.Instance.Fade("in", ()=> FlagManager.Instance.SetFlagState(FlagName.RotationFlag, true));
            }
            );
        }
    }

    private Color ColorChange(Color color)
    {
        time += Time.deltaTime * interval;
        color.a = Mathf.Sin(time) * pulse + initValPalse;
        return color;
    }
}
