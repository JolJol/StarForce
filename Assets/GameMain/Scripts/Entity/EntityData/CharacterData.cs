using System;
using UnityEditor.UIElements;
using UnityEngine;

namespace StarForce
{
    [Serializable]
    public class CharacterData : EntityData
    {
        [SerializeField] private float m_AttackSpeed = 0f;

        [SerializeField] private float m_Attack = 0f;
        [SerializeField] private int m_Level = 1;
        private Vector3 m_Position = Vector3.zero;
        [SerializeField] private float m_AttackAnimLength = 0.97f;

        public Vector3 Position
        {
            get { return m_Position; }
            set { m_Position = value; }
        }
        /// <summary>
        /// 攻击动作耗时
        /// </summary>
        public float AttackAnimLength => m_AttackAnimLength;

        /// <summary>
        /// 攻击速度 单位：次/s
        /// </summary>
        public float AttackSpeed => m_AttackSpeed;

        public float Attack => m_Attack;

        public CharacterData(int entityId, int typeId, Vector3 position) : base(entityId, typeId)
        {
            //读表
            //todo
            m_Position = position;
            m_AttackSpeed = 0.8f;
            m_Attack = 5;
        }
    }
}