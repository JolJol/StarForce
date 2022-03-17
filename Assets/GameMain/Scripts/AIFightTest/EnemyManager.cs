using System;
using System.Collections.Generic;
using StarForce;
using UnityEngine;

namespace GameMain.Scripts.AIFightTest
{
    public class EnemyManager:MonoBehaviour
    {
        private EnemyManager m_Instance;
        private List<Transform> m_Enemies;

        public GameObject EnemyPrefab;

        public EnemyManager Instance
        {
            get => m_Instance;
            set => m_Instance = value;
        }

        private void Awake()
        {
            m_Instance = this;
            m_Enemies = new List<Transform>();
        }

        private void CreateEnmey()
        {
            
        }
        
        public Transform FindEnemyTarget(Vector3 pos)
        {
            Transform target = null;
            float minDis = Mathf.Infinity;
            foreach (var enemy in m_Enemies)
            {
                float dis = Vector3.Distance(pos, enemy.position);
                if (dis < minDis)
                {
                    minDis = dis;
                    target = enemy;
                }
            }
            return target;
        }
    }
}