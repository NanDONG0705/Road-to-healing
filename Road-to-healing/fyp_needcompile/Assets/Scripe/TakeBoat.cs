using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeBoat : MonoBehaviour
{
    public GameObject boat;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        // 检查触发进入区域的是否是玩家
        if (other.CompareTag("Player"))
        {
            Debug.Log("take on boat");
           // player.transform.position = new Vector3(25f, 1.21f, 103.86f);

           boat.transform.parent = player.transform;
            boat.transform.localPosition =new Vector3(0,-1.5f,0.2f);    
         
        }
    }
}
