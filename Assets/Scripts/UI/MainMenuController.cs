using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    public GameObject _begin;
    public GameObject _select;
    public GameObject _course;
    public GameObject _collect;
    public GameObject _title;
    
    public GameObject[] _nullSticker;
    public GameObject[] _sticker;

    public void GetExit() {
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
    public void LoadScene(string name) {
        SceneManager.LoadScene(name);
    }
    public void EnterSelect() {
        _begin.SetActive(false);
        _select.SetActive(true);      
    }
    
    public void EnterCourse() {
        _begin.SetActive(false);
        _course.SetActive(true);
    }
    public void EnterCollect() {
        int[] Count = new int[6];

        for (int i = 0;i < 6;i++) {
            if (PlayerPrefs.GetInt("Sticker" + i) == 6)
            {
                _nullSticker[i].SetActive(false);
                _sticker[i].SetActive(true);
            }   
        }
        _begin.SetActive(false);
        _collect.SetActive(true);
    }
    public void EnterMainMenuForSelect()
    {
        _select.SetActive(false);
        _begin.SetActive(true);
    }
    public void EnterMainMenuForCourse()
    {
        _course.SetActive(false);
        _begin.SetActive(true);
    }
    public void EnterMainMenuForCollect() {
        _collect.SetActive(false);
        _begin.SetActive(true);
    }
    public void LoadArchive() {
        string name = PlayerPrefs.GetString("Scenename");
        if (name!=null) {
            SceneManager.LoadScene(name);
        }
    }
    private void Start()
    {
       
    }
}
