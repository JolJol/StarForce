using GameFramework.Fsm;
using GameFramework.Procedure;

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

        protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);
            GameEntry.Entity.ShowCharacter(new CharacterData(GameEntry.Entity.GenerateSerialId(),800011));
        }

        private void CreateFloors()
        {
        }
    }
}