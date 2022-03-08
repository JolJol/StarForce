using GameFramework.Fsm;
using UnityEngine;
using UnityGameFramework.Runtime;
namespace StarForce
{
    /// <summary>
    /// 敌人闲置状态
    /// </summary>
    public class EnemyIdle:EnemyBase
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
            // Log.Debug("啊 被击中了");
            ChangeState<EnemyStiff>(procedureOwner);
        }
    }
}