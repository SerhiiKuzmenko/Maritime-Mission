using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restarter : MonoBehaviour
{
    [SerializeField] private Button btn;
        
    void Start()
    {

        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
