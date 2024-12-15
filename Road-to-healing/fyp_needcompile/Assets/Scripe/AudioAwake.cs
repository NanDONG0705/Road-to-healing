using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioAwake : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("audio start");
           this.GetComponent<AudioSource>().enabled=true;
        }
    }
}
