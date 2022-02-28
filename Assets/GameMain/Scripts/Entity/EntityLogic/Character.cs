using GameFramework.Fsm;
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
        private IFsm<Character> m_CharacterFsm;
        public Animator CachedAnimator
        {
            get;
            private set;
        }
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            CachedAnimator = GetComponent<Animator>();
            FsmState<Character>[] states = new FsmState<Character>[3];
            states[0] = new CharacterIdle();
            states[1] = new CharacterReady();
            states[2] = new CharacterAttack();
            m_CharacterFsm = GameEntry.Fsm.CreateFsm<Character>(this, states);
        }
        private Vector3 m_TempPos = new Vector3(-16.78f,1.06f,10.75f);
        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            m_CharacterData = userData as CharacterData;
            if (m_CharacterData==null)
            {
                Log.Error("角色数据表无效！！！");
                return;
            }
            m_CharacterFsm.Start<CharacterIdle>();
            CachedTransform.position = m_TempPos;
            CachedTransform.localScale = new Vector3(3,3,3);
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
        }

        public virtual void Hit()
        {
            Log.Debug("Hit");
        }

        private bool m_IsAttackComplete = false;
        public bool IsAttackComplete
        {
            get { return m_IsAttackComplete; }
            set { m_IsAttackComplete = value; }
        }
        public virtual void AttackComplete()
        {
            m_IsAttackComplete=true;
        }
    }
    
}