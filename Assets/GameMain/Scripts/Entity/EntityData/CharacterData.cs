using System;
using UnityEngine;

namespace StarForce
{
    public class CharacterData : EntityData
    {
        [SerializeField] private float m_AttackSpeed = 0f;

        [SerializeField] private float m_Attack = 0f;
        [SerializeField] private int m_level = 1;
        [SerializeField] 
        public CharacterData(int entityId, int typeId) : base(entityId, typeId)
        {
            //读表
            //todo
        }
    }
}