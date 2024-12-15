using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlle : MonoBehaviour
{
    //����һ��Transform���͵���CameraRotation��������ʵ�������ת
    public Transform CameraRotation;

    //��������˽�����͵���Mouse_X,Mouse_Y�ֱ���������������򻬶���ֵ
    private float Mouse_X;
    private float Mouse_Y;

    //���������
    public float MouseSensitivity;

    //����һ���������͵�������¼��X����ת�ĽǶ�
    public float xRotation;

    //����Updata����ÿһ֡����ִ�У����²��ܹ�����ǰһʱ�̵�ֵ
    void Update()
    {
        //��ȡ��������ƶ��������������ȵ�ֵ
        Mouse_X = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        //��ȡ��������ƶ��������������ȵ�ֵ
        Mouse_Y = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

        xRotation = xRotation - Mouse_Y;
        //xRotationֵΪ��ʱ����Ļ���ƣ���xRotationֵΪ��ʱ����Ļ����
        //��������ϻ�����Mouse_YֵΪ��,xRotation-Mouse_Y��ֵΪ��,xRotation�ܵ�ֵΪ������Ļ�ӽ����ϻ���
        //��������»�����Mouse_YֵΪ��,xRotation-Mouse_Y��ֵΪ��,xRotation�ܵ�ֵΪ������Ļ�ӽ����»���
        //����˵����Ҫ������껬���ķ�������Ļ�ƶ��ķ���Ҫ��ͬ

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        //���� value��ֵ��-90f,90f֮��,���xRotation����90f,�򷵻�90f,���xRotationС��-90f,�򷵻�-90f,���߷���xRotation;

        //���������תʱ������Y��Ϊ������ת�ģ�������תʱ������X��Ϊ������ת��
        CameraRotation.Rotate(Vector3.up * Mouse_X);
        //Vector3.up�൱��Vector3(0,1,0),CameraRotation.Rotate(Vector3.up * Mouse_X)�൱��ʹCameraRotation������y����תMouse_X����λ
        //�����������תʱ������Y��Ϊ������ת�ģ���ʱMouse_X������ֵ�Ĵ�С

        //�����������ת�ƶ�ʱ��������򲻻������ƶ��������ڵ�ͷ��̧ͷ�������ƶ�ʱ�����������������������ƶ����������������ҿ�
        //�����ڿ����������������תʱ��Ҫ��֤�͸�����һ��ת��
        this.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        //this.transformָ���CameraRotation��λ��,localRotationָ������ת��
        //transform.localRotation = Quaternion.Eular(x,y,z)������ת��ʱ�򣬰���X-Y-Z�����ת˳��
        //����Χ��X����תx�ȣ�Χ��Y����תy�ȣ�Χ��Z����תz��
        //��������ת���������Ǹ��ڵ㱾������ϵ��������
    }


}
