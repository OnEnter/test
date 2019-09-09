using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UIbase : MonoBehaviour {

    private void Awake()
    {
        Transform[] childs = transform.GetComponentsInChildren<Transform>();
        for (int i = 0; i < childs.Length; i++)
        {
            if(childs[i].name.EndsWith("_X"))
            {
                childs[i].gameObject.AddComponent<UIbehavour>();
            }
        }
    }
    public Transform ManCanvs()
    {
        return UImanager.Insita.MainCans;
    }
    public GameObject GetGameObject(string name)
    {
        return UImanager.Insita.GetGame(transform.name, name);
    }
    public UIbehavour GetBehavour(string name)
    {
        GameObject tmpGame = GetGameObject(name);
        UIbehavour uIbehavour = tmpGame.GetComponent<UIbehavour>();
        if (uIbehavour != null)
            return uIbehavour;
        Debug.Log("未挂载UIbehavour");
        return null;
    }
    #region Destory
    public void DestroyPanel()
    {
        UImanager.Insita.DestroyPanel(this.name);
        Destroy(this.gameObject);
    }
    public void DestoryWeaget(string name)
    {
        UImanager.Insita.DestroyWeaget(this.name, name);
    }
    #endregion
    #region Event
    public void AddDragListen(string name,UnityAction<BaseEventData> action)
    {
        UIbehavour uIbehavour = GetBehavour(name);
        if (uIbehavour != null)
            uIbehavour.AddDragListen(action);
        else
            Debug.Log("未挂载UIbehavour组件");
    }
    #endregion
    #region Weaget
    public void AddbuttonListen(string name,UnityAction action)
    {
        UIbehavour uIbehavour = GetBehavour(name);
        if (uIbehavour != null)
            uIbehavour.Addbutton(action);
        else
        Debug.Log("无uibehavour");
    }
    #endregion
}
