namespace Zoo.Animals
{
    public class Elephant: Animal
    {
        // ReSharper disable NotAccessedField.Local
        private byte[] _leftTusk;
        private byte[] _rightTusk;
        private byte[] _leftFrontFoot;
        private byte[] _leftBackFoot;
        private byte[] _rightFrontFoot;
        private byte[] _rightBackFoot;
        // ReSharper restore NotAccessedField.Local

        public Elephant(IAnimalStatusTracker statusTracker) : base(statusTracker)
        {
            _rightTusk = new byte[0x14000];
            _leftTusk = new byte[0x14000];
            _leftFrontFoot=  new byte[0x14000];
            _leftBackFoot = new byte[0x14000];
            _rightFrontFoot = new byte[0x14000];
            _rightBackFoot = new byte[0x14000];

        }

        public override int LifeInterval
        {
            get { return 100; }
        }

        ~Elephant()
        {
            _rightTusk = _leftTusk = null;
        }
    }
}