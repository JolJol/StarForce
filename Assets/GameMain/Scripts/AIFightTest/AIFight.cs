using System;
using UnityEngine;

namespace GameMain.Scripts.AIFightTest
{
    public class AiFight : MonoBehaviour
    {
        public AiState AiState;
        public float IdleTimer = 0;
        public float IdleTime = 1;
        public float AttackTimer = 0;
        public float AttackTime = 1;
        private void Start()
        {
            AiState = AiState.Idle;
            IdleTimer = Time.time + IdleTime;
        }
        
        private void Update()
        {
            switch (AiState)
            {
                case AiState.Idle:
                    if (Time.time > IdleTimer)
                    {
                        AiState = AiState.FindTarget;
                    }
                    break;
                case AiState.FindTarget:
                    
                    break;
                case AiState.Fight:
                    break;
            }
        }
    }

    public enum AiState
    {
        /// <summary>
        /// 闲置
        /// </summary>
        Idle,

        /// <summary>
        /// 寻找目标
        /// </summary>
        FindTarget,

        /// <summary>
        /// 向目标寻路
        /// </summary>
        NavigateTarget,
        
        /// <summary>
        /// 战斗
        /// </summary>
        Fight,
    }
}