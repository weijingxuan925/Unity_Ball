using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class PassLevel : MonoBehaviour
{
    // get user informatio
    [SerializeField]
    private GameObject _ui;
    [SerializeField]
    private GameObject _passMenu;

    [SerializeField]
    private TextMeshProUGUI _star;

    [SerializeField]
    private TextMeshProUGUI _hpText;
    [SerializeField]
    private TextMeshProUGUI _scoreText;
    [SerializeField]
    private TextMeshProUGUI _timeCountText;

    [SerializeField]
    private int _hpStar;
    [SerializeField]
    private int _scoreStar;
    [SerializeField]
    private int _timeCountStar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            int count = 0;
            int hp = int.Parse(_hpText.text.Split(":")[1]); 
            int score = int.Parse(_scoreText.text.Split(":")[1]);
            int timeCount = int.Parse(_timeCountText.text.Split(":")[1]);
            if(hp >= _hpStar) count++;
            if(score >= _scoreStar) count++;
            if(timeCount >= _timeCountStar) count++;
            if (count == 0) _star.text = "";
            if (count == 1) _star.text = "*";
            if (count == 2) _star.text = "*   *";
            if (count == 3) _star.text = "*   *   *";
            Time.timeScale = 0f;
            _ui.SetActive(false);
            _passMenu.SetActive(true);
        }
    }
}
