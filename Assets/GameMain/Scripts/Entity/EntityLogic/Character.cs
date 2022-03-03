using GameFramework.Fsm;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.AI;
using UnityGameFramework.Runtime;

namespace StarForce
{
    /// <summary>
    /// 角色逻辑类
    /// </summary>
    public class Character:EntityLogic
    {
        [SerializeField]
        private CharacterData m_CharacterData=null;
        [SerializeField]
        private IFsm<Character> m_CharacterFsm;
        public Animator CachedAnimator
        {
            get;
            private set;
        }

        public static int Name = 0;
        protected override void OnInit(object userData)
        {
            Name++;
            base.OnInit(userData);
            CachedAnimator = GetComponent<Animator>();
            FsmState<Character>[] states = new FsmState<Character>[3];
            states[0] = new CharacterIdle();
            states[1] = new CharacterReady();
            states[2] = new CharacterAttack();
            m_CharacterFsm = GameEntry.Fsm.CreateFsm<Character>(Name.ToString(),this, states);
        }
        private readonly Vector3 m_TempPos = new Vector3(-16.78f,1.06f,10.75f);
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
            CachedTransform.position = m_CharacterData.Position;
            CachedTransform.localScale = new Vector3(3,3,3);
            
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
        }

        private Enemy m_TargetEnemy;

        public void SetTarget(Enemy enemy)
        {
            m_TargetEnemy = enemy;
        }
        public void Hit()
        {
            Log.Debug("Hit");
            GameEntry.Entity.ShowArrow(new ArrowData(GameEntry.Entity.GenerateSerialId(),800013,this,m_TargetEnemy));
        }

        private bool m_IsAttackComplete = false;
        public bool IsAttackComplete
        {
            get => m_IsAttackComplete;
            set => m_IsAttackComplete = value;
        }
        public void AttackComplete()
        {
            m_IsAttackComplete=true;
        }
    }
    
}