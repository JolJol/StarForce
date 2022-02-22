namespace StarForce
{
    public class GameTest:GameBase
    {
        public override GameMode GameMode
        {
            get
            {
                return GameMode.Test;
            }
        }

        public override void Initialize()
        {
            base.Initialize();
        }
        
    }
}