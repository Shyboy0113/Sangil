using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject Target; // 카메라가 따라갈 대상
    public float Zpos = -10f; // Z축 위치 오프셋
    public float SmoothSpeed = 5f; // 카메라 이동 속도
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        Vector3 TargetPos = new Vector3(Target.transform.position.x, Target.transform.position.y, Zpos);
        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * SmoothSpeed);
    }
}
