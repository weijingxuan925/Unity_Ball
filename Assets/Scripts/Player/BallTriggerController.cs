using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//玩家触发事件相关脚本
public class BallTriggerController : MonoBehaviour
{
    
    Rigidbody _rb;
    //重生点
    private Vector3 _rebornPoint;
    //是否死了
    private bool _isDeath = false;
    //小球的类型（0、精灵球-质量正常 | 1、高级球-质量轻 | 2、大师球-质量重）
    private int _ballType = 0;
    //材质数组
    [SerializeField]
    private Material[] _ballMaterials;
    [SerializeField]
    private TextMeshProUGUI _hpText;


    private Animator _anim;
    //给小球更换材质
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

    //自定义一个设置重生点的函数
    public void SetRebornPoint(Vector3 res)
    {
        _rb = GetComponent<Rigidbody>();
        _rebornPoint = res;
    }
    //小球重生的方法
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
        //初始化重生点
        _rebornPoint = _rb.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        //小球重生设置
        if (_rb.position.y < 5.0f && !_isDeath)
        {
            int hp = int.Parse(_hpText.text.Split(":")[1]);
            hp--;
            if (hp > 0)
            {
                //打开提示
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
