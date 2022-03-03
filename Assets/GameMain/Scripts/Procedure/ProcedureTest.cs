using GameFramework.Fsm;
using GameFramework.Procedure;
using UnityEngine;

namespace StarForce
{
    public class ProcedureTest:ProcedureBase
    {
        public override bool UseNativeDialog
        {
            get { return false; }
        }

        protected override void OnInit(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnInit(procedureOwner);
        }
        private Vector3 m_Pos1 = new Vector3(-26.77f,1.06f,5.75f);
        protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);
            GameEntry.Entity.ShowCharacter(new CharacterData(GameEntry.Entity.GenerateSerialId(),800011,m_Pos1));
            m_Pos1.z += 5;
            GameEntry.Entity.ShowCharacter(new CharacterData(GameEntry.Entity.GenerateSerialId(),800011,m_Pos1));
            m_Pos1.x += 5;
            GameEntry.Entity.ShowCharacter(new CharacterData(GameEntry.Entity.GenerateSerialId(),800011,m_Pos1));
            m_Pos1.z -= 5;
            GameEntry.Entity.ShowCharacter(new CharacterData(GameEntry.Entity.GenerateSerialId(),800011,m_Pos1));
            m_Pos1.x += 5;
            GameEntry.Entity.ShowCharacter(new CharacterData(GameEntry.Entity.GenerateSerialId(),800011,m_Pos1));
            m_Pos1.z += 5; 
            GameEntry.Entity.ShowCharacter(new CharacterData(GameEntry.Entity.GenerateSerialId(),800011,m_Pos1));
            for (int i = 0; i < 20; i++)
            {
                GameEntry.Entity.ShowEnemy(new EnemyData(GameEntry.Entity.GenerateSerialId(),800012));
            }
        }

        private void CreateFloors()
        {
        }
    }
}