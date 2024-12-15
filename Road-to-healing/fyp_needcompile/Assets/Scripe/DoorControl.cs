using Highlands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DoorControl : MonoBehaviour
{
    public GameObject player;
    public Interactive door;
    private bool close=true;
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
        // 检查触发进入区域的是否是玩家
        if (other.CompareTag("Player") && input.action.WasPressedThisFrame() && close)
        {
            close = false;
            door.PlayInteractiveAnimation();
        }
    }
}
