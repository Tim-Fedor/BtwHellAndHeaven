    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocater : MonoBehaviour {
    
    public static Transform PlayerLocation {
        get {
            if (_instance == null) {
                _instance = LocatePlayer();
            }

            return _instance;
        }
    }

    private static Transform _instance;

    private static Transform LocatePlayer() {
        var players = GameObject.FindGameObjectsWithTag("Player");
        if (players == null || players.Length <= 0) {
            Debug.LogError("PlayerLocater || No player finded");
            return null;
        }

        return players[0].transform;
    }
    void Start() {
        _instance = LocatePlayer();
    }
}
