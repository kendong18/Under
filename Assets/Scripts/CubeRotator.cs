using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Rotate(0, 50*Time.deltaTime, 0);
        }else if (Input.GetKey(KeyCode.KeypadEnter))
        {
            transform.Rotate(0, 50 * Time.deltaTime, 0);
        }
    }
}
