using GameFramework.Fsm;
using UnityEngine;

namespace StarForce
{
    /// <summary>
    /// 闲置状态
    /// </summary>
    public class CharacterIdle:CharacterBase
    {
        protected override void OnInit(IFsm<Character> procedureOwner)
        {
            base.OnInit(procedureOwner);
        }

        protected override void OnEnter(IFsm<Character> procedureOwner)
        {
            base.OnEnter(procedureOwner);
            m_ReadyTimer=Time.time+m_ReadyTime;
        }

        private float m_ReadyTime = 1f;
        private float m_ReadyTimer = 0f;
        protected override void OnUpdate(IFsm<Character> procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
            if (Time.time > m_ReadyTimer)
            {
                ChangeState<CharacterReady>(procedureOwner);
            }
        }

        protected override void OnLeave(IFsm<Character> procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);
        }

        protected override void OnDestroy(IFsm<Character> procedureOwner)
        {
            base.OnDestroy(procedureOwner);
        }
    }
}