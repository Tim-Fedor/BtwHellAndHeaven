using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEventSystemService {
    void AddListener(string eventName, Action<object[]> listener);
    void RemoveListener(string eventName, Action<object[]> listener);
    void DispatchEvent(string eventName, params object[] data);
}
