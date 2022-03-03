using System;
using UnityEngine;

namespace StarForce
{
    [Serializable]
    public class CharacterData : EntityData
    {
        [SerializeField] private float m_AttackSpeed = 0f;

        [SerializeField] private float m_Attack = 0f;
        [SerializeField] private int m_Level = 1;
        [SerializeField] private Vector3 m_Position = Vector3.zero;
        public Vector3 Position
        {
            get
            {
                return m_Position;
            }
            set
            {
                m_Position = value;
            }
        }
        public CharacterData(int entityId, int typeId,Vector3 position) : base(entityId, typeId)
        {
            //读表
            //todo
            m_Position = position;
        }
    }
}