using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // 移動方向
    [SerializeField] private Vector3 speed;
    // 移動速度
    public float moveSpeed = 5.0f;
    //プレイヤー自動回転速度
    [SerializeField] private float applySpeed = 0.2f;
    // カメラ参照用変数
    [SerializeField] private PlayerCamera refCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //WASD移動
        speed = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
            speed.z += 1;
        if (Input.GetKey(KeyCode.A))
            speed.x -= 1;
        if (Input.GetKey(KeyCode.S))
            speed.z -= 1;
        if (Input.GetKey(KeyCode.D))
            speed.x += 1;

        // 速度ベクトルの長さ1秒でmoveSpeedだけ進む
        speed = speed.normalized * moveSpeed * Time.deltaTime;

        //いずれかの方向に移動していたら
        if(speed.magnitude > 0) {
            transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(speed),applySpeed);
            //移動方向にspeedを足しこむ
            transform.position += refCamera.hRotation * speed;
        }
    }
}
