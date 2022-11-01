using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassMenu : MonoBehaviour
{
    public void EnterScene(string name) {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(name);
    }
}
