using System;
using UnityEngine;

namespace StarForce
{
    [Serializable]
    public class EnemyData:EntityData
    {
        public EnemyData(int entityId, int typeId) : base(entityId, typeId)
        {
            //读表
            //todo
        }
    }
}