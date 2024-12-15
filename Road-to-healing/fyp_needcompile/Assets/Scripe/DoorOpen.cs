using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool open = false; // 控制门是否打开的标志
    public float rotationSpeed = 50f; // 门打开时的旋转速度
    public float targetRotationY = 150f; // 门打开时的目标 Y 轴旋转角度

    void Update()
    {
        // 如果门应该打开，并且当前旋转角度小于目标角度
        if (open && transform.rotation.eulerAngles.y < targetRotationY)
        {
            // 计算门应该旋转的角度
            float rotationAmount = rotationSpeed * Time.deltaTime;

            // 通过 Vector3.up 设置门绕 Y 轴旋转
            transform.Rotate(Vector3.up, rotationAmount);
        }
    }
}
