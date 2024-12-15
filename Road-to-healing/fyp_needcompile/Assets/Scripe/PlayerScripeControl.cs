using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScripeControl : MonoBehaviour
{
    public AlongPointMove alongPointMove;
    public PlayerMore playerMore;
    

    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void ScripeSwitch()
    {
        Debug.Log("test");
        playerMore.enabled = true;
        alongPointMove.enabled = false;
        this.enabled = false;
    }

   // Update is called once per frame
   void Update()
    {
        if (Input.GetAxis("Num1") == 1)
        {
            //Debug.Log("1");
            playerMore.enabled=false;
            alongPointMove.enabled = true;
        }
    }
}
