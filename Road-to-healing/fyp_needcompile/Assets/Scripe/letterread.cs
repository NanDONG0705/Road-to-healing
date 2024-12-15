using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class letterread : MonoBehaviour
{

    public GameObject text1;
    public GameObject text2;
    public Transform door;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {


        Destroy(text1); // �ͷ�Unity��Դ
        text1 = null; // �������������Ϊnull���ͷ�C#�������Դ

        Destroy(text2); // �ͷ�Unity��Դ
        text2 = null; // �������������Ϊnull���ͷ�C#�������Դ


        //

        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            door.rotation = Quaternion.Euler(0, -80, 0);
            Destroy(gameObject);
        }
    }
}
