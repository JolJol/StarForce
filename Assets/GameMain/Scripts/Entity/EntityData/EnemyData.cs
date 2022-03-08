using System;
using UnityEngine;

namespace StarForce
{
    [Serializable]
    public class EnemyData:EntityData
    {
        [SerializeField] private float m_MaxHp = 0;
        [SerializeField] private float m_CurrentHp = 0;
        [SerializeField] private float m_MoveSpeed = 0;
        [SerializeField] private float m_Attack = 0;
        [SerializeField] private float m_Level = 1;
        [SerializeField] private float m_HpRatio = 1;

        /// <summary>
        /// 最大生命值
        /// </summary>
        public float MaxHp => m_MaxHp;

        /// <summary>
        /// 当前生命值
        /// </summary>
        public float CurrentHp => m_CurrentHp;

        /// <summary>
        /// 移动速度
        /// </summary>
        public float MoveSpeed => m_MoveSpeed;

        /// <summary>
        /// 攻击力
        /// </summary>
        public float Attack => m_Attack;

        /// <summary>
        /// 等级
        /// </summary>
        public float Level => m_Level;

        public float HpRatio => m_CurrentHp / m_MaxHp;

        public EnemyData(int entityId, int typeId) : base(entityId, typeId)
        {
            //读表
            //todo
            m_MaxHp = 100;
            m_CurrentHp = m_MaxHp;
        }

        public void OnHit(float damage)
        {
            m_CurrentHp -= damage;
            if (m_CurrentHp <= 0)
            {
                m_CurrentHp = m_MaxHp;
            }
        }
    }
}