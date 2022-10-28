using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


//���������صĽű�
public class PlayerAttributeManager : MonoBehaviour
{
    //�����������
    [SerializeField]
    private int _maxHp = 1;
    private int _currentHp;
    //��Ϸ�÷�
    private int _score = 0;
    //UI����
    [SerializeField]
    private TextMeshProUGUI _hpText;
    [SerializeField]
    private TextMeshProUGUI _scoreText;

    //��UI�ַ����õ���ʼ����
    private int GetScore() {
        string _sCount = _scoreText.text.Split(":")[1];
        return int.Parse(_sCount);
    }
    //��UI�ַ����õ���ʼ����
    private int GetCurrentHp() {
        string _sCurrentHp = _hpText.text.Split(":")[1];
        return int.Parse(_sCurrentHp);
    }
    //���·�
    public void SetScore(int score) {
        _score += score;
        _scoreText.text = "Score:" + _score.ToString();
    }
    //������
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
        //��ʼ��
        _score = GetScore();
        _currentHp = GetCurrentHp();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
