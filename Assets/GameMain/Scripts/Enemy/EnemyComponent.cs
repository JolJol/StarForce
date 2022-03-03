using System;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace StarForce
{
    public class EnemyComponent:GameFrameworkComponent
    {
        [SerializeField]
        private Dictionary<int, Enemy> m_Enemies = new Dictionary<int, Enemy>();
        
        protected override void Awake()
        {
            base.Awake();
        }

        public Dictionary<int,Enemy> Enemies => m_Enemies;

        public void AddEnemy(Enemy enemy)
        {
            m_Enemies.Add(enemy.Entity.Id,enemy);
        }
        
        public Enemy GetEnemy()
        {
            foreach (KeyValuePair<int,Enemy> enemy in Enemies)
            {
                return enemy.Value;
            }

            return null;
            
        }
        /// <summary>
        /// 返回最近的敌人
        /// </summary>
        /// <returns></returns>
        public Enemy GetNearestEnemy(Vector3 pos)
        {
            float minDis=Mathf.Infinity;
            Enemy nearestEnemy = null;
            foreach (KeyValuePair<int,Enemy> enemy in Enemies)
            {
                float dis = Vector3.Distance(pos, enemy.Value.CachedTransform.position);
                if (dis < minDis)
                {
                    minDis = dis;
                    nearestEnemy = enemy.Value;
                }
            }
            return nearestEnemy;
        }
    }
}