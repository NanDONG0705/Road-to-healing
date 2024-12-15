using UnityEngine;

public class PlayAnimationOnStart : MonoBehaviour
{
    public Animator animator; // 在 Inspector 中指定 Animator 组件
   

    void Start()
    {
        // 确保 animator 不为空，并且 animationName 已经被指定
        if (animator != null )
        {
            animator.Play("Fadein");
        }
    }
}