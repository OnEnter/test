using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class NpcBase : MonoBehaviour {
    public enum AnimatorEnum
    {
        Idle,
        Walk,
        Run,
        Attack,
        Die,
        Max
    }
    protected FSMManager fSMManager;
    public virtual void Insitial(sbyte max)
    {
        fSMManager = new FSMManager(max);
    }
    protected CharacterController characterController;
    public virtual void Move(Vector3 speed)
    {
        characterController.SimpleMove(speed);
    }
    public virtual void Change(sbyte State)
    {
        fSMManager.Chanage(State);
    }
}
