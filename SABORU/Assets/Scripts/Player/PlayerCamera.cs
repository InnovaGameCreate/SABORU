using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    // カメラの垂直回転(見下ろし回転)
    [SerializeField] private Quaternion vRotation;
    // カメラの水平回転
    [SerializeField] public Quaternion hRotation;
    // カメラ回転速度
    [SerializeField] private float turnSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = hRotation * vRotation;
        vRotation = transform.rotation;
        hRotation = Quaternion.identity;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetMouseButton(0))
        hRotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * turnSpeed, 0);
        transform.rotation = hRotation * vRotation;
    }
}
