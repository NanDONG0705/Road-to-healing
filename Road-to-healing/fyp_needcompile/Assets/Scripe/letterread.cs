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


        Destroy(text1); // 释放Unity资源
        text1 = null; // 将对象的引用置为null，释放C#层面的资源

        Destroy(text2); // 释放Unity资源
        text2 = null; // 将对象的引用置为null，释放C#层面的资源


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
