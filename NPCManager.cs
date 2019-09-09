using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour {
    public static NPCManager Instance;
    private Transform play;
    List<NpcBase> allNpc;
    public Transform Play
    {
        get
        {
            if (play == null)
                play = GameObject.FindGameObjectWithTag("Player").transform;
            return play;
        }
    }
    private void Awake()
    {
        Instance = this;
        allNpc = new List<NpcBase>();
    }
    public void AddNpcList(NpcBase npc)
    {
        allNpc.Add(npc);
    }
    public void DestroyNpcList(NpcBase npc)
    {
        if (allNpc.Contains(npc))
            allNpc.Remove(npc);
    }
}
