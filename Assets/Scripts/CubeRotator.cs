using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // public float moveSpeed = 5f;
    // private Rigidbody rb;

    // void Start()
    // {
    //     rb = GetComponent<Rigidbody>();
    // }

    // void Update()
    // {
    //     // if (Input.GetKey(KeyCode.Space))
    //     // {
    //     //     transform.Rotate(0, 50 * Time.deltaTime, 0);
    //     // }
    //     // else if (Input.GetKey(KeyCode.KeypadEnter))
    //     // {
    //     //     transform.Rotate(0, 50 * Time.deltaTime, 0);
    //     // }

    //     // 1. 사용자 입력받기 
    //     float horizontalInput = Input.GetAxis("Horizontal"); // 좌우 입력
    //     float verticalInput = Input.GetAxis("Vertical"); // 상하 입력

    //     // 2. 이동 방향 계산하기 
    //     Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);

    //     // 3. 오브젝트 이동시키기
    //     // transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    //     rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    // }










    public float moveSpeed = 5f;
    private Rigidbody rb; // Rigidbody 컴포넌트를 담을 변수

    // 게임이 시작될 때 한번만 호출됨
    void Start()
    {
        // 이 스크립트가 붙어있는 게임 오브젝트의 Rigidbody 컴포넌트를 찾아서 rb 변수에 할당
        rb = GetComponent<Rigidbody>();
    }

    // FixedUpdate는 물리 계산을 할 때 사용하는 Update입니다.
    void FixedUpdate()
    {
        // --- 이동 로직 ---
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);

        // --- 회전 로직 ---
        if (Input.GetKey(KeyCode.Space))
        {
            // 회전은 transform.Rotate를 그대로 사용해도 괜찮습니다.
            transform.Rotate(0, 50 * Time.deltaTime, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 부딪힌 상대방(collision.gameObject)의 태그가 "Goal"인지 확인합니다.
        if (collision.gameObject.CompareTag("Goal"))
        {
            // 조건이 맞다면, 콘솔 창에 메시지를 출력합니다.
            Debug.Log("골인!");
        }
    }

}
