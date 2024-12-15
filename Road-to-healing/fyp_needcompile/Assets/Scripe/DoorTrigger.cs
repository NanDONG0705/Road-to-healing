using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DoorTrigger : MonoBehaviour
{

    public GameObject player;
    public DoorController controller;
    public InputActionReference input;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerStay(Collider other)
    {
        // ��鴥������������Ƿ������
        if (other.CompareTag("Player") && input.action.WasPressedThisFrame())
        {
            controller.open = true;
        }
    }
}
