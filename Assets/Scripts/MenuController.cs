using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void GetExit() {
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;//用于退出运行
        #else
            Application.Quit();
        #endif
    }
    public void LoadScene(string name) {
        SceneManager.LoadScene(name);
    }
}
