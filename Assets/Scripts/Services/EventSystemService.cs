using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystemService : MonoBehaviour, IEventSystemService
    {
        public static IEventSystemService Instance { get; private set; }
        
        private Dictionary<string, List<Action<object[]>>> _events;

        public void Awake()
        {
            _events = new Dictionary<string, List<Action<object[]>>>();
            if (Instance != null && Instance != this) 
            { 
                Destroy(this); 
            } 
            else 
            { 
                Instance = this; 
            } 
        }

        public void AddListener(string eventName, Action<object[]> listener)
        {
            if (!_events.ContainsKey(eventName))
            {
                CreateNewPair(eventName);
            }
            AddActionToListeners(eventName, listener);
        }
    
        public void RemoveListener(string eventName, Action<object[]> listener)
        {
            if (!_events.ContainsKey(eventName))
            {
                return;
            }
            RemoveActionFromListeners(eventName, listener);
        }    
    
        public void DispatchEvent(string eventName, params object[] data)
        {

            if (!_events.ContainsKey(eventName))
            {
                return;
            }
            List<Action<object[]>> allActions;
            _events.TryGetValue(eventName, out allActions);
            if (allActions == null)
            { 
                return;
            }

            foreach (var action in allActions)
            {
                action?.Invoke(data);
            }
        }
    
        private void CreateNewPair(string eventName)
        {
            List<Action<object[]>> value = new List<Action<object[]>>();
            _events.Add(eventName, value);
        }
    
        private void AddActionToListeners(string eventName, Action<object[]> newListener)
        {
            List<Action<object[]>> allActions;
            _events.TryGetValue(eventName, out allActions);
            if (allActions == null)
            {
                Debug.LogWarning($"Can`t get ActionList from {eventName}");
                allActions = new List<Action<object[]>>();
            }

            if (allActions.Contains(newListener))
            {
                Debug.LogWarning($"Already have listener in {eventName}");
                return;
            }
            allActions.Add(newListener);
        }    
    
        private void RemoveActionFromListeners(string eventName, Action<object[]> listener)
        {
            List<Action<object[]>> allActions;
            _events.TryGetValue(eventName, out allActions);
            if (allActions == null)
            {
                Debug.LogWarning($" ActionList from {eventName} is null");
                return;
            }

            if (!allActions.Contains(listener))
            {
                Debug.LogWarning($"Listener in {eventName} is already removed");
                return;
            }
            allActions.Remove(listener);
        }
    }
