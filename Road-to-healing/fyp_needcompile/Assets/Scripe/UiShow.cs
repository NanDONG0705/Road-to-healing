using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiShow : MonoBehaviour
{
    public float fadeInDuration = 10.0f; // 渐变持续时间
    public TextMeshProUGUI textMeshPro; // 在Unity编辑器中拖拽TextMeshProUGUI组件到这个变量中
    private Color originalColor;
    private Color targetColor;

    void Start()
    {
        originalColor = textMeshPro.color;
        targetColor = new Color(originalColor.r, originalColor.g, originalColor.b, 1.0f);


      
    }

    IEnumerator FadeIn()
    {
        float elapsedTime = 0.0f;
        while (elapsedTime < fadeInDuration)
        {
            float alpha = Mathf.Lerp(0.0f, 1.0f, elapsedTime / fadeInDuration); // 计算当前透明度
            Color newColor = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            textMeshPro.color = newColor;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 确保最终透明度为不透明
       // textMeshPro.color = targetColor;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")==true)
            {
            StartCoroutine(FadeIn());
        }
    }
       


}
