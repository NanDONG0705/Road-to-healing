using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public Animator animator;
    private bool isTriggered = false; // ��ֹ��δ���
    public int SenceNum;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTriggered)
        {
            isTriggered = true; // ����Ϊ�Ѵ���
            Debug.Log("scene change");
            StartCoroutine(LoadSceneAfterAnimation());
        }
    }

    IEnumerator LoadSceneAfterAnimation()
    {
        animator.Play("Fadeout");
        // �ȴ���������ʱ�䣬������趯��ʱ��ԼΪ1��
        yield return new WaitForSeconds(1.5f);
        // ���س���
        SceneManager.LoadScene(SenceNum);
    }
}