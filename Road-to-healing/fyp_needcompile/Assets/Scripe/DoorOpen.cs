using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool open = false; // �������Ƿ�򿪵ı�־
    public float rotationSpeed = 50f; // �Ŵ�ʱ����ת�ٶ�
    public float targetRotationY = 150f; // �Ŵ�ʱ��Ŀ�� Y ����ת�Ƕ�

    void Update()
    {
        // �����Ӧ�ô򿪣����ҵ�ǰ��ת�Ƕ�С��Ŀ��Ƕ�
        if (open && transform.rotation.eulerAngles.y < targetRotationY)
        {
            // ������Ӧ����ת�ĽǶ�
            float rotationAmount = rotationSpeed * Time.deltaTime;

            // ͨ�� Vector3.up �������� Y ����ת
            transform.Rotate(Vector3.up, rotationAmount);
        }
    }
}
