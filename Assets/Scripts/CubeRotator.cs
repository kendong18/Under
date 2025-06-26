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
    public float moveSpeed = 5f;
    void Update()
    {
        // if (Input.GetKey(KeyCode.Space))
        // {
        //     transform.Rotate(0, 50 * Time.deltaTime, 0);
        // }
        // else if (Input.GetKey(KeyCode.KeypadEnter))
        // {
        //     transform.Rotate(0, 50 * Time.deltaTime, 0);
        // }

        // 1. 사용자 입력받기 
        float horizontalInput = Input.GetAxis("Horizontal"); // 좌우 입력
        float verticalInput = Input.GetAxis("Vertical"); // 상하 입력

        // 2. 이동 방향 계산하기 
        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);

        // 3. 오브젝트 이동시키기
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}
