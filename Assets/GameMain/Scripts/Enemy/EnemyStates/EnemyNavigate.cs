using GameFramework.Fsm;
using UnityEngine;

namespace StarForce
{
    /// <summary>
    /// 敌人寻路状态
    /// </summary>
    public class EnemyNavigate:EnemyBase
    {
        private Animator m_Animator;
        private Enemy m_Enemy;

        protected override void OnInit(IFsm<Enemy> procedureOwner)
        {
            base.OnInit(procedureOwner);
            m_Enemy = procedureOwner.Owner;
            m_Animator = m_Enemy.CachedAnimator;
        }

        protected override void OnEnter(IFsm<Enemy> procedureOwner)
        {
            base.OnEnter(procedureOwner);
        }

        protected override void OnUpdate(IFsm<Enemy> procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds); 
        }

        public override void OnHit(IFsm<Enemy> procedureOwner)
        {
            
        }
    }
}