using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform trans;//�����

    public Transform Target;//������Ŀ��

    public Vector3 DisVector = new Vector3(0, 2, -5);//�������
    // Start is called before the first frame update
    void Start()
    {
        trans = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        trans.position = Target.position + DisVector;
        trans.LookAt(Target);//ʼ�տ���Target
    }
}
