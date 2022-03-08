using System;
using UnityEditor.U2D;
using UnityEngine;

namespace StarForce
{
    [Serializable]
    public class ArrowData:EntityData
    {
        private Character m_Shooter;
        private Enemy m_Target;
        private float m_Attack;

        /// <summary>
        /// 攻击力
        /// </summary>
        public float Attack => m_Attack;

        public Character Shooter => m_Shooter;
        
        public Enemy Target => m_Target;

        public ArrowData(int entityId, int typeId,Character shooter,Enemy target) : base(entityId, typeId)
        {
            //读表
            //todo
            m_Shooter = shooter;
            m_Target = target;
            m_Attack = shooter.CharacterData.Attack;
        }
    }
}