using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UIbehavour : MonoBehaviour {
    private void Awake()
    {
        UIbase tmpBase = GetComponentInParent<UIbase>();
        UImanager.Insita.Registered(tmpBase.name, this.name, this.gameObject);
    }
    #region Event
    public void AddDragListen(UnityAction<BaseEventData> action)
    {
        EventTrigger tmpTrigger = GetComponent<EventTrigger>();
        if (tmpTrigger == null)
            tmpTrigger = gameObject.AddComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry
        {
            eventID = EventTriggerType.Drag,
            callback = new EventTrigger.TriggerEvent()
        };
        entry.callback.AddListener(action);
        tmpTrigger.triggers.Add(entry);
    }
    #endregion
    #region
    public void Addbutton(UnityAction action)
    {
        Button button = GetComponent<Button>();
        if (button != null)
            button.onClick.AddListener(action);
        else
        Debug.Log("无Button");
    }
    #endregion
}
