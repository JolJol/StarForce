using System;
using UnityEditor.UIElements;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace StarForce
{
    /// <summary>
    /// 投掷物基础类
    /// </summary>
    public class Arrow:EntityLogic
    {
        [SerializeField]
        private ArrowData m_ArrowData;

        private Character m_Shooter;
        private Enemy m_Target;
        private float m_Speed = 20f;
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            m_ArrowData = userData as ArrowData;
            if (m_ArrowData == null)
            {
                Log.Error("投掷物数据表无效");
                return;
            }

            m_Shooter = m_ArrowData.Shooter;
            m_Target = m_ArrowData.Target;
            CachedTransform.position = m_Shooter.CachedTransform.position + new Vector3(0, 1.279f, 0.25f);
            CachedTransform.rotation = Quaternion.identity;
            Vector3 v1 = CachedTransform.forward;
            v1.y = 0;
            Vector3 v2 = m_Target.CachedTransform.position - CachedTransform.position;
            v2.y = 0;
            Quaternion quaternion = Quaternion.FromToRotation(v1,v2);
            CachedTransform.rotation = quaternion;

            //生成一个石头试试 

        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
            CachedTransform.Translate(CachedTransform.forward*m_Speed*elapseSeconds,Space.World);
        }

        private void OnTriggerEnter(Collider other)
        {
            // throw new NotImplementedException();
            if (other.gameObject == m_Target.gameObject)
            {
                GameEntry.Entity.HideEntity(this.Entity);
                m_Target.OnHit();
            }
        }
    }
}