using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    //�ֵ��Ƿ���ã�����ҹ����Ҫ�صƵ������
    /*[SerializeField]
    private bool streetLampLightEnabled;*/
    //ʱ���������������ʱ��
    [SerializeField]
    private float timeMultiplier;
    //��������������������װ��ͬʱҲ��Inspector�з���
    //��ʾUI�еĸ��ı���������ʾ24Сʱ�Ƶ�ʱ��
    [SerializeField]
    private TextMeshProUGUI timeText;

    //��ʼʱ��
    [SerializeField]
    private float startHour;

    //��ǰ/�ճ�/���� ʱ��
    private DateTime currentTime;
    private TimeSpan sunriseTime;
    private TimeSpan sunsetTime;


    //�ճ�/���� Сʱ
    [SerializeField]
    private float sunriseHour;
    [SerializeField]
    private int sunsetHour;

    //��ȡ�����
    [SerializeField]
    private Light sunLight;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = DateTime.Now.Date + TimeSpan.FromHours(startHour);
        sunriseTime = TimeSpan.FromHours(sunriseHour);
        sunsetTime = TimeSpan.FromHours(sunsetHour);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimeOfDay();
        RotateSunLight();
    }
    /// <summary>
    /// �����ı��ķ���
    /// </summary>
    private void UpdateTimeOfDay()
    {
        //�������ʱ��
        currentTime = currentTime.AddSeconds(Time.deltaTime * timeMultiplier);
        //����UI�ı���ʾʱ��
        if (timeText != null)
        {
            timeText.text = "Time:" + currentTime.ToString("HH:mm");
        }
    }
    /// <summary>
    /// ��ת�����
    /// </summary>
    private void RotateSunLight()
    {
        float sunLightRotation;
        if (currentTime.TimeOfDay > sunriseTime && currentTime.TimeOfDay < sunsetTime)
        {
            //�����������ʱ���
            TimeSpan sunriseToSunsetDuration = CalculateTimeDifference(sunriseTime, sunsetTime);
            //���ճ�����ǰʱ���ʱ���
            TimeSpan timeSinceSunrise = CalculateTimeDifference(sunriseTime, currentTime.TimeOfDay);
            //�����ǰʱ������ʱ��ı���
            double percentage = timeSinceSunrise.TotalMinutes / sunriseToSunsetDuration.TotalMinutes;

            //Mathf.Lerp����(a,b,t)
            //�� a �� b ֮�䰴 t �������Բ�ֵ��
            //���� t �����ڷ�Χ[0, 1] �ڡ�
            sunLightRotation = Mathf.Lerp(0, 180, (float)percentage);

            //����ƹ�������ȡStreetLampLight��ǩ����Ϸ����
            /*if (streetLampLightEnabled)
            {
                GameObject[] streetLamps = GameObject.FindGameObjectsWithTag("StreetLampLight");
                //��������
                foreach (GameObject streetLamp in streetLamps)
                {
                    //��ȡ������������Ϸ����Ĺ�Դ���
                    Light streetLampLight = streetLamp.GetComponent<Light>();
                    if (streetLampLight != null)
                    {
                        //����ص�
                        streetLampLight.enabled = false;
                    }
                }
            }*/
        }
        else
        {
            //���䵽������ʱ���
            TimeSpan sunsetToSunriseDuration = CalculateTimeDifference(sunsetTime, sunriseTime);
            //�����䵽��ǰʱ���ʱ���
            TimeSpan timeSinceSunset = CalculateTimeDifference(sunsetTime, currentTime.TimeOfDay);
            //�����ǰʱ������ʱ��ı���
            double percentage = timeSinceSunset.TotalMinutes / sunsetToSunriseDuration.TotalMinutes;

            sunLightRotation = Mathf.Lerp(180, 360, (float)percentage);

            //���Ƶƹ�
            /*if (streetLampLightEnabled)
            {
                GameObject[] streetLamps = GameObject.FindGameObjectsWithTag("StreetLampLight");
                foreach (GameObject streetLamp in streetLamps)
                {
                    Light streetLampLight = streetLamp.GetComponent<Light>();
                    if (streetLampLight != null)
                    {
                        streetLampLight.enabled = true;
                    }
                }
            }*/
        }
        //�������Χ������ת�Ƕ�---��������Ԫ��(�Ƕ�,��)
        sunLight.transform.rotation = Quaternion.AngleAxis(sunLightRotation, Vector3.right);

    }
    /// <summary>
    /// �Զ������ʱ���ķ���
    /// </summary>
    /// <param name="fromTime"></param>
    /// <param name="toTime"></param>
    /// <returns></returns>
    private TimeSpan CalculateTimeDifference(TimeSpan fromTime, TimeSpan toTime)
    {
        TimeSpan diff = toTime - fromTime;
        if (diff.TotalSeconds < 0)
        {
            diff += TimeSpan.FromHours(24);
        }
        return diff;
    }
}
