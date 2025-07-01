using UnityEngine;

// CharacterController 컴포넌트가 반드시 필요하다고 명시
[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    //  공개 변수 (Public Variables) - 인스펙터 창에서 수정 가능 
    public float walkSpeed = 10f; // 걷는 속도
    public float lookSpeed = 2f; // 마우스 감도 
    public float lookXlimit = 45.0f; // 고개를 위아래로 움직일 수 있는 각도 제한

    // 비공개 변수 (Private Variables) - 스크립트 내부에서만 사용
    private CharacterController characterController;
    private Camera playerCamera;
    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;

    void Start()
    {
        //필요한 컴포넌트들을 가져와서 변수에 할당
        characterController = GetComponent<CharacterController>();
        playerCamera = Camera.main; // 씬의 메인 카메라를 찾음

        // 게임 시작 시 마우스 커서를 숨기고 화면 중앙에 고정
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // --- 1. 플레이어 이동처리 ---
        // 플레이어의 앞/뒤, 좌우 방향을 월드 기준으로 변환
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        // WASD 키 입력 받음 (W/S는 Vertical, A/D는 Horizontal)
        float curSpeedX = walkSpeed * Input.GetAxis("Vertical");
        float curSpeedY = walkSpeed * Input.GetAxis("Horizontal");

        // 이동 방향 계산
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        // 계산된 방향으로 플레이어 이동 (CharacterController 사용)
        characterController.Move(moveDirection * Time.deltaTime);


        // --- 2. 카메라 시점 처리 --- 
        // 마우스 입력을 받아와서 회전 값 계산
        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXlimit, lookXlimit); // 상하 시점 각도 제한

        // 카메라의 상하 회전 적용
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        // 플레이어 몸 전체의 좌우 회전 적용
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        
    }
}
