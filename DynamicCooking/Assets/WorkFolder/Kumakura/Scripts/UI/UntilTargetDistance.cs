using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UntilTargetDistance : MonoBehaviour
{

    private Text timeText;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject syariObj;
    private float distance;

    void Start()
    {
        timeText = GetComponent<Text>();
    }

    void Update()
    {
        distance = Vector3.Distance(player.transform.position, syariObj.transform.position) * 10;
        timeText.text = distance.ToString("0");
    }
}
