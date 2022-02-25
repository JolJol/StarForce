using UnityEditor.U2D;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace StarForce
{
    /// <summary>
    /// 角色逻辑类
    /// </summary>
    public class Character:Entity
    {
        private CharacterData m_CharacterData=null;
        public Animator CachedAnimator
        {
            get;
            private set;
        }
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            CachedAnimator = GetComponent<Animator>();
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            m_CharacterData = userData as CharacterData;
            if (m_CharacterData==null)
            {
                Log.Error("角色数据表无效！！！");
                return;
            }
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
        }

        protected virtual void Attack()
        {
            
        }
    }
    
}