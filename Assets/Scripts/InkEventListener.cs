using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkEventListener : MonoBehaviour
{
    // 存储所有可能的事件
    public List<InkEvent> _inkEventsList;

    // 通过事件名称触发事件
    public void TriggerEvent(string eventName)
    {
        foreach (var gameEvent in _inkEventsList)
        {
            if (gameEvent._eventName.Equals(eventName, System.StringComparison.OrdinalIgnoreCase))
            {
                gameEvent._inkEvent.Invoke();
                return;
            }
        }
        Debug.LogWarning($"No game event found with name: {eventName}");
    }
}