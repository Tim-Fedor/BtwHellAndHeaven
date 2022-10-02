using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFollow : MonoBehaviour {
    [SerializeField]
    private CinemachineVirtualCamera _virtualCamera;
    void Start() {
        _virtualCamera.m_Follow = PlayerLocater.PlayerLocation;
        EventSystemService.Instance.AddListener(EventConstants.TIMER_UP, TimesUp);
    }
    
    private void TimesUp(object[] data) {
        _virtualCamera.gameObject.SetActive(false);
        _virtualCamera.PreviousStateIsValid = false;
        _virtualCamera.transform.position = PlayerLocater.PlayerLocation.transform.position;
        _virtualCamera.gameObject.SetActive(true);
        //_virtualCamera.ForceCameraPosition(PlayerLocater.PlayerLocation.transform.position, _virtualCamera.transform.rotation);
    }
}
