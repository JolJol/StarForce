﻿using GameFramework.Fsm;
using UnityEngine;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<StarForce.Enemy>;
namespace StarForce
{
    /// <summary>
    /// 敌人僵直状态
    /// </summary>
    public class EnemyStiff:EnemyBase
    {
        private Animator m_Animator;
        private Enemy m_Enemy;
        protected override void OnInit(IFsm<Enemy> procedureOwner)
        {
            base.OnInit(procedureOwner);
            m_Enemy = procedureOwner.Owner;
            m_Animator = m_Enemy.CachedAnimator;
        }
        
        private readonly int m_OnHitPara = Animator.StringToHash("OnHit");
        private readonly int m_OnHitFromHitPara = Animator.StringToHash("OnHitFromHit");
        private readonly int m_OnHitFromHit2Para = Animator.StringToHash("OnHitFromHit2");
        
        protected override void OnEnter(IFsm<Enemy> procedureOwner)
        {
            base.OnEnter(procedureOwner);
            m_Animator.SetTrigger(m_OnHitPara);
        }

        protected override void OnUpdate(IFsm<Enemy> procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
        }

        protected override void OnLeave(IFsm<Enemy> procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);
        }

        protected override void OnDestroy(IFsm<Enemy> procedureOwner)
        {
            base.OnDestroy(procedureOwner);
        }
        
        public override void OnHit(IFsm<Enemy> procedureOwner)
        {
            m_Animator.SetTrigger(m_OnHitPara);
        }

        public void OnStiffEnd(IFsm<Enemy> procedureOwner)
        {
            ChangeState<EnemyIdle>(procedureOwner);
        }
    }
}