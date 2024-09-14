using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ModeChanger : MonoBehaviour
{
    [SerializeField] private Button _btn;
    [SerializeField] private TextMeshProUGUI _mode;
    int modeSettings = 1;

    string[] modes = { "Ease", "Middle", "Hard" };

    void Start()
    {
        _btn.onClick.AddListener(TaskOnClick);
    }


    void TaskOnClick()
    {
        _mode.text = "Mode:" + modes[modeSettings];
        PlayerPrefs.SetString("Difficulty", _mode.text);
        modeSettings++;
        if (modeSettings > 2)
            modeSettings = 0;
    }

    
}
