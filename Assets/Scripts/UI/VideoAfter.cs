using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoAfter : MonoBehaviour
{
    [SerializeField]
    private string _name;

    float _time = 35f;
    float _timer = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_timer <= _time)
        {
            _timer += Time.deltaTime;

        }
        else
        {
            SceneManager.LoadScene(_name);
        }
    }
}
