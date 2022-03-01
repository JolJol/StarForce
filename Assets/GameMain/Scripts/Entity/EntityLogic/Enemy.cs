using GameFramework.Fsm;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace StarForce
{
    public class Enemy:Entity
    {
        private EnemyData m_EnemyData = null;
        private IFsm<Enemy> m_EnemyFsm;

        public Animator CachedAnimator
        {
            get;
            private set;
        }

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            CachedAnimator = GetComponent<Animator>();
            
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            m_EnemyData = userData as EnemyData;
            if (m_EnemyData == null)
            {
                Log.Error("敌人数据表无效");
                return;
            }
            
        }
        
    }
}