using GameFramework.Fsm;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace StarForce
{
    public class Enemy:EntityLogic
    {
        private EnemyData m_EnemyData = null;
        private IFsm<Enemy> m_EnemyFsm;

        public Animator CachedAnimator
        {
            get;
            private set;
        }
        private readonly Vector3 m_TempPos = new Vector3(-25.52f,1.06f,22.81f);
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

            CachedTransform.position = m_TempPos;
            CachedTransform.localScale = new Vector3(3,3,3);
            CachedTransform.Rotate(Vector3.up,180);
            GameEntry.EnemyManager.AddEnemy(this);
        }

        private int m_OnHitPara = Animator.StringToHash("OnHit");
        public void OnHit()
        {
            CachedAnimator.SetTrigger(m_OnHitPara);
        }
    }
}