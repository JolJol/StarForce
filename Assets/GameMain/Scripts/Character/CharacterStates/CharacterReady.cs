using System.Timers;
using GameFramework.Fsm;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

namespace StarForce
{
    /// <summary>
    /// 准备状态
    /// </summary>
    public class CharacterReady:CharacterBase
    {
        private CharacterData m_CharacterData;
        private Animator m_Animator;
        private Character m_Character;
        protected override void OnInit(IFsm<Character> procedureOwner)
        {
            base.OnInit(procedureOwner);
            m_Character = procedureOwner.Owner;
            m_Animator = m_Character.CachedAnimator;
        }

        private readonly int m_ReadyPara = Animator.StringToHash("Ready");
        private readonly int m_AttackSpeedMultiplier = Animator.StringToHash("AttackSpeedMultiplier");
        protected override void OnEnter(IFsm<Character> procedureOwner)
        {
            base.OnEnter(procedureOwner);
            m_Animator.SetTrigger(m_ReadyPara);
            m_CharacterData = m_Character.CharacterData;
            m_AttackTime = 1/m_CharacterData.AttackSpeed;
            if (m_AttackTime > m_CharacterData.AttackAnimLength)
            {
                m_AttackTimer = Time.time + m_AttackTime-m_CharacterData.AttackAnimLength;
                m_Animator.SetFloat(m_AttackSpeedMultiplier,1);
            }
            else
            {
                m_AttackTimer = 0;
                m_Animator.SetFloat(m_AttackSpeedMultiplier,m_CharacterData.AttackAnimLength/m_AttackTime);
            }
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
                m_Character.CachedTransform.LookAt(m_TargetEnemy.CachedTransform);
            }
            else
            {
                m_TargetEnemy = GameEntry.EnemyManager.GetNearestEnemy(procedureOwner.Owner.CachedTransform.position);
                m_Character.SetTarget(m_TargetEnemy);
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