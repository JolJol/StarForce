using System;
using GameFramework.Fsm;
using UnityEngine;
using UnityGameFramework.Runtime;
using Random = UnityEngine.Random;
using UnityGameFramework.Runtime;

namespace StarForce
{
    public class Enemy : Entity
    {
        private EnemyData m_EnemyData = null;
        private IFsm<Enemy> m_EnemyFsm;
        private bool m_IsOnHit;
        public Animator CachedAnimator { get; private set; }

        public EnemyData EnemyData => m_EnemyData;

        public bool IsOnHit { get; set; }

        private static int s_Name = 0;

        private Vector3 m_TempPos = new Vector3(-25.52f, 1.06f, 22.81f);

        protected override void OnInit(object userData)
        {
            s_Name++;
            base.OnInit(userData);
            CachedAnimator = GetComponent<Animator>();
            FsmState<Enemy>[] states = new FsmState<Enemy>[2];
            states[0] = new EnemyIdle();
            states[1] = new EnemyStiff();
            m_EnemyFsm = GameEntry.Fsm.CreateFsm(s_Name.ToString(), this, states);
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

            m_TempPos.x = Random.Range(-31, -13);
            m_TempPos.z = Random.Range(18, 36);
            CachedTransform.position = m_TempPos;
            CachedTransform.localScale = new Vector3(3, 3, 3);
            CachedTransform.Rotate(Vector3.up, 180);
            GameEntry.EnemyManager.AddEnemy(this);
            m_EnemyFsm.Start<EnemyIdle>();
        }

        private readonly int m_OnHitPara = Animator.StringToHash("OnHit");

        public void OnHit(float damage)
        {
            CachedAnimator.SetTrigger(m_OnHitPara);
            var fromHpRatio = m_EnemyData.HpRatio;
            m_EnemyData.OnHit(damage);
            var toHpRatio = m_EnemyData.HpRatio;
            if (fromHpRatio > toHpRatio)
            {
                GameEntry.HpBar.ShowHPBar(this, fromHpRatio, toHpRatio);
            }
            m_IsOnHit = true;
            (m_EnemyFsm.CurrentState as EnemyBase)?.OnHit(m_EnemyFsm);
        }

        public void OnStiffEnd()
        {
            (m_EnemyFsm.CurrentState as EnemyStiff)?.OnStiffEnd(m_EnemyFsm);
        }
    }
}