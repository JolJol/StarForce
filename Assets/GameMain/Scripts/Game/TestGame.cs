namespace StarForce
{
    public class TestGame:GameBase
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
            CreateFloors();
        }

        private void CreateFloors()
        {
            
        }
    }
}