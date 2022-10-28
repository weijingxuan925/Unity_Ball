using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//��Ҵ����¼���ؽű�
public class BallTriggerController : MonoBehaviour
{
    
    Rigidbody _rb;
    //������
    private Vector3 _rebornPoint;
    //�Ƿ�����
    private bool _isDeath = false;
    //С������ͣ�0��������-�������� | 1���߼���-������ | 2����ʦ��-�����أ�
    private int _ballType = 0;
    //��������
    [SerializeField]
    private Material[] _ballMaterials;
    [SerializeField]
    private TextMeshProUGUI _hpText;


    private Animator _anim;
    //��С���������
    public void SetBallType(int type)
    {
        this.GetComponent<Renderer>().material = _ballMaterials[type];

        if (_ballType != type)
        {
            if (type == 0)
            {
                _rb.mass = 4.0f;
                _rb.drag = 1.0f;
                _rb.angularDrag = 0.05f;
            }
            if (type == 1)
            {
                _rb.mass = 2.0f;
                _rb.drag = 0.1f;
                _rb.angularDrag = 0.05f;
            }
            if (type == 2)
            {
                _rb.mass = 8.0f;
                _rb.drag = 1.5f;
                _rb.drag = 0.1f;
            }
        }
    }

    //�Զ���һ������������ĺ���
    public void SetRebornPoint(Vector3 res)
    {
        _rb = GetComponent<Rigidbody>();
        _rebornPoint = res;
    }
    //С�������ķ���
    public void RebornBall()
    {
        this.transform.position = _rebornPoint;
        _rb.velocity = Vector3.zero;
        _rb.constraints = RigidbodyConstraints.FreezeAll;
        _rb.constraints = RigidbodyConstraints.None;
    }
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        //��ʼ��������
        _rebornPoint = _rb.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        //С����������
        if (_rb.position.y < 5.0f && !_isDeath)
        {
            int hp = int.Parse(_hpText.text.Split(":")[1]);
            hp--;
            if (hp > 0)
            {
                //����ʾ
                GameObject.Find("Util").GetComponent<DeahMenu>().ShowDeahMenu();

            }
            else {
                GameObject.Find("Util").GetComponent<DeahMenu>().ShowGameOverMenu();
            }
            _hpText.text = "Hp:" + hp.ToString();
            _isDeath = true;
        }
        else if (_rb.position.y >= 5.0f)
        {
            _isDeath = false;
        }
    }
}
