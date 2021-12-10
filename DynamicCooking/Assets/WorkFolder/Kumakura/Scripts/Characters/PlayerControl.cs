using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public GameObject player;
    public Rigidbody body;
    [SerializeField] private float moveSpeed = 0.1f;
    [SerializeField] private float minAngle;
    [SerializeField] private float maxAngle;
    private Vector3 gyroPosition;

    private Vector3 inputPosition;

    float currentXAngle;
    float currentYAngle;
    float currentZAngle;

    //public Text aaa;
    //public Text bbb;
    //public Text ccc;

    private bool[] nums = new bool[4];

    // この辺あとでまとめる
    public GameObject buttonParent;
    public Image targetImage;
    public Text timeText;
    public Image retryImage;
    public Image sushiImage;

    void Start()
    {
        //Input.gyro.enabled = true;
        
    }

    void Update()
    {
        if (FlagManager.Instance.GetFlagState(FlagName.GameStart) &&
            FlagManager.Instance.GetFlagState(FlagName.Push))
        {
            PlayerMove();
        }
    }


    private void PlayerMove()
    {
        //UpdateGyroData();
        currentXAngle = transform.eulerAngles.x;
        currentYAngle = transform.eulerAngles.y;
        currentZAngle = transform.eulerAngles.z;

        if (currentXAngle > 180) currentXAngle = currentXAngle - 360;
        if (currentYAngle > 180) currentYAngle = currentYAngle - 360;
        if (currentZAngle > 180) currentZAngle = currentZAngle - 360;

        // 前に傾けて加速
        if (Input.GetKey(KeyCode.W) || gyroPosition.x < -5 || nums[0])
        {
            body.AddForce(Vector3.forward * 0.25f);
            if (currentXAngle <= maxAngle)
            {
                transform.Rotate(new Vector3(moveSpeed, 0, 0));
            }
        }

        // 左に傾けて左に加速
        if (Input.GetKey(KeyCode.A) || gyroPosition.y < -5 || nums[1])
        {
            body.AddForce(Vector3.left * 0.25f);
            if (currentZAngle <= maxAngle)
            {
                transform.Rotate(new Vector3(0, 0, moveSpeed));
            }
        }

        // 後ろに傾けて減速
        if (Input.GetKey(KeyCode.S) || gyroPosition.x > 5 || nums[2])
        {
            // マイナスの値にはしない
            if (body.velocity.z > 0)
            {
                body.AddForce(Vector3.back * 0.25f);
            }
            if (currentXAngle > minAngle)
            {
                transform.Rotate(new Vector3(-moveSpeed, 0, 0));
            }
        }

        // 右に傾けて右に加速
        if (Input.GetKey(KeyCode.D) || gyroPosition.y > 5 || nums[3])
        {
            body.AddForce(Vector3.right * 0.25f);
            if (currentZAngle > minAngle)
            {
                transform.Rotate(new Vector3(0, 0, -moveSpeed));
            }
        }

        //aaa.text = gyroPosition.x.ToString();
        //bbb.text = gyroPosition.y.ToString();
        //ccc.text = gyroPosition.z.ToString();



    }


    /// <summary>
    /// ボタン用
    /// </summary>
    /// <param name="_id"></param>
    public void InputNum(int _id)
    {
        nums[_id] = true;
    }

    public void PushUpNum(int _id)
    {
        nums[_id] = false;
    }


    private void UpdateGyroData()
    {
        gyroPosition.x = (Input.gyro.rotationRate.x * 180) / Mathf.PI;
        gyroPosition.y = (Input.gyro.rotationRate.y * 180) / Mathf.PI;
        gyroPosition.z = (Input.gyro.rotationRate.z * 180) / Mathf.PI;
    }

    public void ImageNotView()
    {
        buttonParent.SetActive(false);
        targetImage.enabled = false;
        timeText.enabled = false;
        retryImage.enabled = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Goal")
        {
            //// ゴール判定
            //FlagManager.Instance.SetFlagState(FlagName.GameStart, false);
            //ImageNotView();
            //sushiImage.enabled = true;
            //FlagManager.Instance.SetFlagState(FlagName.RotationFlag, true);
        }

        else if (other.gameObject.tag == "Other")
        {
            // 爆発判定
            FlagManager.Instance.SetFlagState(FlagName.GameStart, false);
            ImageNotView();
        }
    }


}
