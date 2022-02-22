using UnityEngine;

namespace StarForce
{
    /// <summary>
    /// 角色逻辑类
    /// </summary>
    public class Character:Entity
    {
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