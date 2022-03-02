using System.Collections.Generic;
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
    }
}