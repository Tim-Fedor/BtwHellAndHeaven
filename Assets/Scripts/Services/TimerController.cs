using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour {
    public const float maxTimer = 10f;
    [SerializeField]
    private TMP_Text _timerText;

    private float CurrentTime {
        get {
            return _curTime;
        }
        set {
            _curTime = value;
            _timerText.text = _curTime.ToString("0.0",  System.Globalization.CultureInfo.InvariantCulture);
        }
    }

    private float _curTime;
    private bool _isTimerOn;
    void Start() {
        CurrentTime = maxTimer;
        _isTimerOn = true;
    }
    
    void Update()
    {
        if (_isTimerOn) {
            if (CurrentTime > 0) {
                CurrentTime -= Time.deltaTime;
            }
            else {
                EventSystemService.Instance.DispatchEvent(EventConstants.TIMER_UP);
                CurrentTime = maxTimer;
            }
        }
    }
}
