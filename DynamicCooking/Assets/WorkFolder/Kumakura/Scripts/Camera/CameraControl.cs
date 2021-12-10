using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    [SerializeField] private float rotateSpeed = 20f;
    [SerializeField] private GameObject centerObject = null;
    private Vector3 offset;

    [SerializeField] private StartImageControl startImageControl;

    private bool rotationTrigger = false;


    void Start()
    {
        // 中心になるオブジェクトとの一定距離を取得
        offset = transform.position - centerObject.transform.position;
    }

    void Update()
    {
        transform.position = centerObject.transform.position + offset;
        // オブジェクトを中心としてカメラの回転
        if (FlagManager.Instance.GetFlagState(FlagName.RotationFlag))transform.RotateAround(centerObject.transform.position, Vector3.up, rotateSpeed * Time.deltaTime);
        // 距離の再取得
        offset = transform.position - centerObject.transform.position;
        if ((int)transform.rotation.eulerAngles.y % 360 == 0 && rotationTrigger == false)
        {
            rotationTrigger = true;
            FlagManager.Instance.SetFlagState(FlagName.RotationFlag, false);
            // StartImageの表示
            startImageControl.StartAnim();
        }
    }
}
