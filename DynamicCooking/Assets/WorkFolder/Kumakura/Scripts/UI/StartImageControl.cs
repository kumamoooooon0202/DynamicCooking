using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartImageControl : MonoBehaviour
{
    public Image startImage;
    private Animator anim;
    [SerializeField] private Image targetImage;
    [SerializeField] private Text timeText;

    [SerializeField] private GameObject buttons;


    void Start()
    {
        anim = GetComponent<Animator>();
        startImage = GetComponent<Image>();
        buttons.SetActive(false);
    }

    void Update()
    {
        
    }

    public void StartAnim()
    {
        anim.SetTrigger("StartFlag");
    }

    public void GameStart()
    {
        FlagManager.Instance.SetFlagState(FlagName.GameStart, true);
        targetImage.enabled = true;
        timeText.enabled = true;
        buttons.SetActive(true);
    }
}
