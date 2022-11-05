using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//µ¹¼ÆÊ±½Å±¾
public class CountDownController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _timeRemainingText;

    [SerializeField]
    private float _totalTime = 300.0f;

    bool _isDeath = false;
    IEnumerator CountDown()
    {
        while(_totalTime >= 0){
            _timeRemainingText.text = "TimeRemaining" + ":" + _totalTime.ToString();
            yield return new WaitForSeconds(1);
            _totalTime--;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountDown());
    }
    private void Update()
    {
        if (_totalTime < 0 && !_isDeath) {
            GameObject.Find("Util").GetComponent<DeahMenu>().ShowGameOverMenu();
            _isDeath = true;
        }
    }
}
