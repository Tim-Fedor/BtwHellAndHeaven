using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFollow : MonoBehaviour {
    [SerializeField]
    private CinemachineVirtualCamera _playerPos;
    void Start() {
        _playerPos.m_Follow = PlayerLocater.PlayerLocation;
    }
    
    
}
