using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public Animator animator;
    private bool isTriggered = false; // 防止多次触发
    public int SenceNum;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTriggered)
        {
            isTriggered = true; // 设置为已触发
            Debug.Log("scene change");
            StartCoroutine(LoadSceneAfterAnimation());
        }
    }

    IEnumerator LoadSceneAfterAnimation()
    {
        animator.Play("Fadeout");
        // 等待动画播放时间，这里假设动画时长约为1秒
        yield return new WaitForSeconds(1.5f);
        // 加载场景
        SceneManager.LoadScene(SenceNum);
    }
}