using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UImanager : MonoBehaviour {

    private Dictionary<string, Dictionary<string, GameObject>> allWeaget;
    private Transform mainCans;
    public Transform MainCans
    {
        get
        {
            return mainCans;
        }
    }
    public static UImanager Insita;
    private void Awake()
    {
        Insita = this;
        mainCans = GameObject.FindGameObjectWithTag("ManCanvs").transform;
        allWeaget = new Dictionary<string, Dictionary<string, GameObject>>();
    }
    public void Registered(string panelName,string weagerName,GameObject weager)
    {
        if (!allWeaget.ContainsKey(panelName))
            allWeaget[panelName] = new Dictionary<string, GameObject>();
        allWeaget[panelName].Add(weagerName, weager);
    }
    #region Destroy
    /// <summary>
    /// 删除子物体
    /// </summary>
    /// <param name="panelName"></param>
    /// <param name="weagerName"></param>
    public void DestroyWeaget(string panelName, string weagerName)
    {
        if (allWeaget.ContainsKey(panelName))
        {
            if (allWeaget[panelName].ContainsKey(weagerName))
            {
                allWeaget[panelName].Remove(weagerName);
            }
            else
                Debug.Log("无子物体");
        }
        else
            Debug.Log("无Panel");
    }
    /// <summary>
    /// 删除Panel
    /// </summary>
    /// <param name="panelName"></param>
    public void DestroyPanel(string panelName)
    {
        if (allWeaget.ContainsKey(panelName))
        {
            allWeaget[panelName].Clear();
            allWeaget[panelName] = null;
            allWeaget.Remove(panelName);
        }
    }
    #endregion

    public GameObject GetGame(string panelName,string weagerName)
    {
        if(allWeaget.ContainsKey(panelName))
        {
            if(allWeaget[panelName].ContainsKey(weagerName))
            {
                return allWeaget[panelName][weagerName];
            }
        }
        Debug.Log("未获取到子物体");
        return null;
    }
}
