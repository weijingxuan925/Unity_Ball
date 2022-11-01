using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    //街灯是否可用（用于夜晚需要关灯的情况）
    /*[SerializeField]
    private bool streetLampLightEnabled;*/
    //时间乘数，用来加速时间
    [SerializeField]
    private float timeMultiplier;

    [SerializeField]
    private TextMeshProUGUI timeText;

    //初始时间
    [SerializeField]
    private float startHour;

    //当前/日出/日落 时间
    private DateTime currentTime;
    private TimeSpan sunriseTime;
    private TimeSpan sunsetTime;


    //日出/日落 小时
    [SerializeField]
    private float sunriseHour;
    [SerializeField]
    private int sunsetHour;

    //获取定向光
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
   
    private void UpdateTimeOfDay()
    {
        //这里加速时间
        currentTime = currentTime.AddSeconds(Time.deltaTime * timeMultiplier);
        //更新UI文本显示时间
        if (timeText != null)
        {
            timeText.text = "Time:" + currentTime.ToString("HH:mm");
        }
    }

    // 旋转定向关

    private void RotateSunLight()
    {
        float sunLightRotation;
        if (currentTime.TimeOfDay > sunriseTime && currentTime.TimeOfDay < sunsetTime)
        {
            //日升到日落的时间差
            TimeSpan sunriseToSunsetDuration = CalculateTimeDifference(sunriseTime, sunsetTime);
            //从日出到当前时间的时间差
            TimeSpan timeSinceSunrise = CalculateTimeDifference(sunriseTime, currentTime.TimeOfDay);
            //算出当前时间差和总时间的比率
            double percentage = timeSinceSunrise.TotalMinutes / sunriseToSunsetDuration.TotalMinutes;

    
            sunLightRotation = Mathf.Lerp(0, 180, (float)percentage);

        }
        else
        {
            //日落到日升总时间差
            TimeSpan sunsetToSunriseDuration = CalculateTimeDifference(sunsetTime, sunriseTime);
            //从日落到当前时间的时间差
            TimeSpan timeSinceSunset = CalculateTimeDifference(sunsetTime, currentTime.TimeOfDay);
            //算出当前时间差和总时间的比率
            double percentage = timeSinceSunset.TotalMinutes / sunsetToSunriseDuration.TotalMinutes;

            sunLightRotation = Mathf.Lerp(180, 360, (float)percentage);

   
        }
        //将定向光围绕轴旋转角度---参数是四元数(角度,轴)
        sunLight.transform.rotation = Quaternion.AngleAxis(sunLightRotation, Vector3.right);

    }

    /// <param name="fromTime"></param>
    /// <param name="toTime"></param>

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
