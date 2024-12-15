using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMore : MonoBehaviour
{
    //����һ���ƶ��ٶ�MoveSpeed ������Ϊpublic����
    public float MoveSpeed;
    //�û���PlayerMove�ű�������Զ�����е���
    //����public���壬�ű�������޸ģ����Խű����޸ĵ�Ϊ����
    //�������private������ֻ���ڽű��޸ģ�

    //��������˽�����͵ĸ���������horizontal��vertical����¼A��D����
    //W��S�������ݣ�Ҳ�������Ϊ��¼ˮƽ�����ֱ������ݣ���X���Y��
    private float horizontal;
    private float vertical;

    //����һ������gravity
    private float gravity = 9.8f;
    //����һ�������ٶ�
    public float JumpSpeed = 15f;
    //����һ���������͵�CharacterController����������ΪPlayerController
    //����ʵ��������
    public CharacterController PlayerController;

    //����һ��Vector3
    //Vector3�����ȿ���������ʾλ�ã�Ҳ����������ʾ����
    //��������ά����ϵ��,�ֱ�ȡ��x�ᡢy��,z�᷽����ͬ��3����λ����i��j, k��Ϊһ����ס�
    //��aΪ������ϵ�ڵ�����������������ԭ��OΪ���������OP=a���ɿռ��������֪������ֻ��һ��ʵ����x��y, z��
    //ʹ�� a=����OP=xi+yj+zk����˰�ʵ���ԣ�x��y, z����������a������
    //����a=��x��y, z�������������a�������ʾ�����У�x��y, z��,Ҳ���ǵ�P�����ꡣ����OP��Ϊ��P��λ��������
    Vector3 Player_Move;
    //������ǲ����Ļ�����ȥCSDN����ϸ�˽⣬����Ͳ�������˵����

    //����Updata����ÿһ֡����ִ�У����²��ܹ�����ǰһʱ�̵�ֵ
    void Update()
    {
        //�ж�PlayerController�Ƿ��ڵ����ϣ���������ڵ����ϾͲ��ܹ�ǰ�������ƶ���Ҳ���ܹ�����
        if (PlayerController.isGrounded)
        {
            //Input.GetAxis("Horizontal")Ϊ��ȡX(����)�᷽���ֵ��horizontal
            horizontal = Input.GetAxis("Horizontal");
            //Input.GetAxis("Vertical")Ϊ��ȡZ(����)�᷽���ֵ��Vertical
            vertical = Input.GetAxis("Vertical");

            //transformΪ����������λ�ã�forward����ǰ��һ������
            //transform.forward * verticalΪ������ǰ�ķ���˻�ȡ��Z���ֵ����������ǰ�ƶ����������verticalΪ���������������
            //transform.right * horizontalΪ�������ҵķ���˻�ȡ��X���ֵ�������������ƶ����������horizonΪ����������������
            //������Ӻ��������ƶ����ȣ���ֵ��Vector3���͵�Player_Move��Ϊ����ʵ���˶��ķ���
            Player_Move = (transform.forward * vertical + transform.right * horizontal) * MoveSpeed;

            //�ж�����Ƿ��¿ո��
            if (Input.GetAxis("Jump") == 1)
            {
                //���¿ո����������ֱ�������һ�����ϵ����ȣ�ʹ������
                //Player_Move.y�൱��Player_Move�µ�Vector3(0,1,0)
                Player_Move.y = Player_Move.y + JumpSpeed;
            }


        }

        //ģ�������½���Ч���������ϵ�����ȥ�����½�����
        //����deltaTime��ʾΪunity���ر�������ΪTime���е������ڸ�֡�б����£��ڸ�֡�У��ñ�����ʾ�˾���һ֡��������ʱ��ֵ��������㣩��
        //����������ŵ㣺 ʹ��������������������Ϸ֡�����޹� ����Update���������еĴ�������֡��ִ�е�
        //������Ҫ���ƶ��������������ִ�У�������deltaTime��Ϳ���ʵ��
        //���磺����һ����Ϸ������ǰ��ÿ��10m�ƶ��Ļ� ������ٶ�10��Time.deltaTime ����ʾÿ���ƶ��ľ���Ϊ10m������ÿ֡10m
        Player_Move.y = Player_Move.y - gravity * Time.deltaTime;

        //PlayerController�µ�.MoveΪʵ�������˶��ĺ���
        //Move()�����ڷ���һ��Vector3���͵�����������ΪPlayer_Move
        PlayerController.Move(Player_Move * Time.deltaTime);
    }


}
