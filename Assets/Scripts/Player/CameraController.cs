using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    /*private float _rSpeed = 5.0f;

    private float X;

    private float Y;*/

    private Transform trans;//摄像机

    public Transform Target;//被跟踪目标

    public Vector3 DisVector = new Vector3(0, 2, -5);//跟随距离
    // Start is called before the first frame update
    void Start()
    {
        trans = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        /*X += Input.GetAxis("Mouse X") * _rSpeed;
        Y += Input.GetAxis("Mouse Y") * _rSpeed;
        transform.localRotation = Quaternion.AngleAxis(Target.position.x, Vector3.up);
        transform.localRotation *= Quaternion.AngleAxis(Target.position.y, Vector3.left);*/


        trans.position = Target.position + DisVector;
        trans.LookAt(Target);//始终看向Target
    }
}
