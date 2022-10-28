using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


//玩家属性相关的脚本
public class PlayerAttributeManager : MonoBehaviour
{
    //玩家生命属性
    [SerializeField]
    private int _maxHp = 1;
    private int _currentHp;
    //游戏得分
    private int _score = 0;
    //UI文字
    [SerializeField]
    private TextMeshProUGUI _hpText;
    [SerializeField]
    private TextMeshProUGUI _scoreText;

    //从UI字符串得到初始分数
    private int GetScore() {
        string _sCount = _scoreText.text.Split(":")[1];
        return int.Parse(_sCount);
    }
    //从UI字符串得到初始生命
    private int GetCurrentHp() {
        string _sCurrentHp = _hpText.text.Split(":")[1];
        return int.Parse(_sCurrentHp);
    }
    //更新分
    public void SetScore(int score) {
        _score += score;
        _scoreText.text = "Score:" + _score.ToString();
    }
    //更新命
    public void SetCurrentHp(int hp) {
        if (_currentHp + hp <= _maxHp && _currentHp + hp > 0) 
        {
            _currentHp += hp;
            _hpText.text = "Hp:" + hp.ToString();
        }
        else if(_currentHp + hp < 0){
            
        }

        
    }
    // Start is called before the first frame update
    void Start()
    {
        //初始化
        _score = GetScore();
        _currentHp = GetCurrentHp();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
