using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.FilePathAttribute;




public class Test : MonoBehaviour
{

    public InputActionReference input;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (input.action.WasPressedThisFrame())
        {
            Debug.Log("A ");
        }
           
    }
}
