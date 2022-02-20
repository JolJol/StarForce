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
            CreateFloors();
        }

        private void CreateFloors()
        {
            GameEntry.Entity.ShowFloors(new FloorData(GameEntry.Entity.GenerateSerialId(),80001));
        }
    }
}