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
        _virtualCamera.ForceCameraPosition(PlayerLocater.PlayerLocation.transform.position, _virtualCamera.transform.rotation);
    }
}
