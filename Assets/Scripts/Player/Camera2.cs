using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2 : MonoBehaviour
{
    private Transform player; //���

    private Transform watchPoint; //ע��Ŀ���
    private float watchPointHeight = 2f; //ע��Ŀ���߶�

    private float distance = 5f; //��ǰ �������Ŀ������
    private float distanceMax = 8f; //��Ŀ���������
    private float distanceMin = 1.0f; //��Ŀ�����С����
    private float distanceSpeed = 0.3f; //���������ٶ�

    private float rotationY; //ˮƽ��ת
    private float rotationYSpeed = 3f; //ˮƽ��ת�ٶ�

    private float AngleLerp; //��ǰ��ֱ�Ƕ� ��ֵϵ��
    private float AngleMax = 80.0f; //���ֱ�Ƕ�
    private float AngleMin = -40.0f; //��С��ֱ�Ƕ�
    private float AngleSpeed = 0.02f; //��ֱ��ת�ٶ�

    private Vector3 finalVec = new Vector3(); //����ƫ������

    private void Start()
    {
        //Ѱ�ұ�ǩ ������Transform
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //ʵ����ע��Ŀ�������
        watchPoint = new GameObject().transform;
    }

    private void FixedUpdate()
    {
        ChangeDistance(); //�������� �������Ŀ������
        ChangeRotationY(); //ˮƽ��ת
        ChangeAngle(); //��ֱ��ת
        FinalCameraPos(); //���������λ��
    }

    private void ChangeDistance() //�������� �������Ŀ������
    {
        //��������������
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            //�ı� ��ǰ��Ŀ������
            distance += distanceSpeed;
            //���� ��Ŀ���������ֵ
            if (distance > distanceMax)
            {
                distance = distanceMax;
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            //�ı� ��ǰ��Ŀ������
            distance -= distanceSpeed;
            //���� ��Ŀ��������Сֵ
            if (distance < distanceMin)
            {
                distance = distanceMin;
            }
        }
    }

    private void ChangeRotationY() //ˮƽ��ת
    {
        //������X���ƶ�ֵ �޸�ˮƽ��תֵ
        rotationY = Input.GetAxis("Mouse X") * rotationYSpeed;
        //ע��Ŀ��� ˮƽ��ת
        watchPoint.Rotate(0, rotationY, 0);
    }

    private void ChangeAngle() //��ֱ��ת
    {
        //���Y���ƶ� �޸� ��ֱ�ǶȲ�ֵϵ��
        AngleLerp -= Input.GetAxis("Mouse Y") * AngleSpeed;

        //���� ��ֱ�ǶȲ�ֵϵ�� �����Сֵ
        if (AngleLerp > AngleMax / 90.0f) //��90�� ��� ��� ��ֱ�ǶȲ�ֵϵ��
        {
            AngleLerp = AngleMax / 90.0f;
        }
        else if (AngleLerp < AngleMin / 90.0f)
        {
            AngleLerp = AngleMin / 90.0f;
        }

        //�ж� ��ǰ��ֱ�ǶȲ�ֵϵ�� ����
        //���� ע��Ŀ���� ������ �Ϸ����·����� �� ��ǰ��ֱ�ǶȲ�ֵϵ��
        //��� ƫ�������ķ���
        if (AngleLerp > 0)
            finalVec = Vector3.Lerp(-watchPoint.forward, watchPoint.up, AngleLerp);
        else
            finalVec = Vector3.Lerp(-watchPoint.forward, -watchPoint.up, -AngleLerp); //��ֱ�ǶȲ�ֵϵ�� ȡ��

        finalVec.Normalize(); //��λ��ƫ����������Ϊ1
        finalVec *= distance; //�趨 ƫ�������ĳ���
    }

    private void FinalCameraPos() //���������λ��
    {
        //ע��Ŀ���λ�� ���� ���λ��
        Vector3 PointPos = player.position;
        PointPos.y += watchPointHeight; //�޸� ע��Ŀ��� �߶�
        //�����ƶ�Ч�� ��ֵʵ��
        watchPoint.position = Vector3.Lerp(watchPoint.position, PointPos, 0.9f);

        //�����λ�� ����ע��Ŀ���λ�� ����ƫ��
        Vector3 cameraPos = watchPoint.position + finalVec;
        //�����ƶ�Ч�� ��ֵʵ��
        transform.position = Vector3.Lerp(transform.position, cameraPos, 0.2f);
        //�����ʼ�տ��� ע��Ŀ���
        transform.LookAt(watchPoint.position);
    }
}
