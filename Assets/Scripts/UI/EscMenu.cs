using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EscMenu : MonoBehaviour
{
    //暂停菜单脚本
    [SerializeField]
    private GameObject _escMenu;

    public void Continue() {
        //解除暂停
        Time.timeScale = 1.0f;
        _escMenu.SetActive(false);
    }
    public void Save() { 
    
    }
    public void ExitGame() {
        #if UNITY_EDITOR
                EditorApplication.isPlaying = false;//用于退出运行
        #else
                Application.Quit();
        #endif
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Time.timeScale = 0;
            _escMenu.SetActive(true);
        }
    }
}
