using GameFramework.Fsm;
using UnityEngine;

namespace StarForce
{
    /// <summary>
    /// 攻击状态
    /// </summary>
    public class CharacterAttack:CharacterBase
    {
        protected override void OnInit(IFsm<Character> procedureOwner)
        {
            base.OnInit(procedureOwner);
        }

        private readonly int m_AttackPara = Animator.StringToHash("Attack");
        protected override void OnEnter(IFsm<Character> procedureOwner)
        {
            base.OnEnter(procedureOwner);
            procedureOwner.Owner.CachedAnimator.SetTrigger(m_AttackPara);
            procedureOwner.Owner.IsAttackComplete = false;
        }
        protected override void OnUpdate(IFsm<Character> procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
            if (procedureOwner.Owner.IsAttackComplete)
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