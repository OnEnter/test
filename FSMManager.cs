using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMManager : MonoBehaviour {
    Fsm[] allState;
    public FSMManager(int StateCount)
    {
        allState = new Fsm[StateCount];
    }
    public sbyte curState = -1, stateIndex = -1;
    public sbyte GetStateIndex()
    {
        return stateIndex;
    }
    public void AddState(Fsm fsm)
    {
        if (curState > allState.Length)
            return;
        curState++;
        allState[curState] = fsm;
    }
    public void Chanage(sbyte index)
    {
        if (index > allState.Length - 1)
            return;
        if (index == stateIndex)
            return;
        if (stateIndex != -1)
            allState[stateIndex].OnExit();
        stateIndex = index;
        allState[stateIndex].OnEnter();
    }
    public void Stay()
    {
        if (stateIndex != -1)
            allState[stateIndex].OnStay();
    }
}
public class Fsm
{
    NPCManager
    public virtual void OnEnter()
    {

    }
    public virtual void OnStay()
    {

    }
    public virtual void OnExit()
    {

    }
}
