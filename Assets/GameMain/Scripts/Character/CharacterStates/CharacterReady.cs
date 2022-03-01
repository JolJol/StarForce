using GameFramework.Fsm;
using UnityEditor.UIElements;
using UnityEngine;

namespace StarForce
{
    /// <summary>
    /// 准备状态
    /// </summary>
    public class CharacterReady:CharacterBase
    {
        protected override void OnInit(IFsm<Character> procedureOwner)
        {
            base.OnInit(procedureOwner);
        }

        private readonly int m_ReadyPara = Animator.StringToHash("Ready");
        protected override void OnEnter(IFsm<Character> procedureOwner)
        {
            base.OnEnter(procedureOwner);
            procedureOwner.Owner.CachedAnimator.SetTrigger(m_ReadyPara);
            m_AttackTimer = Time.time + m_AttackTime;
        }

        private float m_AttackTime = 0.5f;
        private float m_AttackTimer = 0f;
        protected override void OnUpdate(IFsm<Character> procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
            if (Time.time > m_AttackTimer)
            {
                ChangeState<CharacterAttack>(procedureOwner);
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