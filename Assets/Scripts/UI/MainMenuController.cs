using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    public GameObject Begin;
    public GameObject Select;
    public GameObject Course;
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
    public void EnterSelect() {
        Begin.SetActive(false);
        Select.SetActive(true);      
    }
    
    public void EnterCourse() {
        Begin.SetActive(false);
        Course.SetActive(true);
    }
    public void EnterMainMenuForSelect()
    {
        Select.SetActive(false);
        Begin.SetActive(true);
    }
    public void EnterMainMenuForCourse()
    {
        Course.SetActive(false);
        Begin.SetActive(true);
    }
}
