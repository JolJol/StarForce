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
            m_TargetEnemy = null;
        }

        private float m_AttackTime = 0.5f;
        private float m_AttackTimer = 0f;
        private Enemy m_TargetEnemy;
        protected override void OnUpdate(IFsm<Character> procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
            if (m_TargetEnemy)
            {
                if (Time.time > m_AttackTimer)
                {
                    ChangeState<CharacterAttack>(procedureOwner);
                }
                //朝向目标
                procedureOwner.Owner.CachedTransform.LookAt(m_TargetEnemy.CachedTransform);
            }
            else
            {
                m_TargetEnemy = GameEntry.EnemyManager.GetEnemy();
                procedureOwner.Owner.SetTarget(m_TargetEnemy);
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