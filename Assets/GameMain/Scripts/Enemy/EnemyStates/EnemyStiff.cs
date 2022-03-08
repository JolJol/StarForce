using GameFramework.Fsm;

namespace StarForce
{
    /// <summary>
    /// 敌人僵直状态
    /// </summary>
    public class EnemyStiff:EnemyBase
    {
        protected override void OnInit(IFsm<Enemy> procedureOwner)
        {
            base.OnInit(procedureOwner);
        }

        protected override void OnEnter(IFsm<Enemy> procedureOwner)
        {
            base.OnEnter(procedureOwner);
        }

        protected override void OnUpdate(IFsm<Enemy> procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
        }

        protected override void OnLeave(IFsm<Enemy> procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);
        }

        protected override void OnDestroy(IFsm<Enemy> procedureOwner)
        {
            base.OnDestroy(procedureOwner);
        }   
    }
}