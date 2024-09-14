using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResourceUI : MonoBehaviour
{
    private int _resourceNumber = 0;
    private float _timeToWin = 20f;
    private float _currentTime;
    [SerializeField] private TextMeshProUGUI _resourceNumverUI;
    [SerializeField] private TextMeshProUGUI _timeUI;
    //private ModeChanger _modeChanger;
   
    void Start()
    {
        _currentTime = _timeToWin+1;
        _resourceNumber = GameObject.FindGameObjectsWithTag("Resource").Length;
        _resourceNumverUI.text = _resourceNumber.ToString();
        string _mode = PlayerPrefs.GetString("Difficulty");

        //Debug.Log(_mode);
        //_modeChanger = FindObjectOfType<ModeChanger>();
        if (_mode == "Mode:Ease")
        {
            _currentTime = 50f;
        }else if(_mode == "Mode:Middle")
        {
            _currentTime = 30f;
        }
        else
        {
            _currentTime = 20f;
        }


    }

    public void Update()
    {
        if (_currentTime > 0)
        {
            _currentTime-=Time.deltaTime;
            UpdateTimerText();
        }
        else
        {
            _currentTime=0;
            _timeUI.text = string.Format("{0:00}:{1:00}", 0, 0);
            SceneManager.LoadScene("EndingScene");
        }
    }

    public void resourceUpdate()
    {
        _resourceNumber--;
        _resourceNumverUI.text = _resourceNumber.ToString();
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(_currentTime / 60);
        int seconds = Mathf.FloorToInt(_currentTime % 60);

        _timeUI.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public int getResourceNumber()
    {
        return _resourceNumber;
    }

}
