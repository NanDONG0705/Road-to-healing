using UnityEngine;

public class PlayAnimationOnStart : MonoBehaviour
{
    public Animator animator; // �� Inspector ��ָ�� Animator ���
   

    void Start()
    {
        // ȷ�� animator ��Ϊ�գ����� animationName �Ѿ���ָ��
        if (animator != null )
        {
            animator.Play("Fadein");
        }
    }
}