using System.Collections.Generic;

//Generated code
namespace DarkIslandGen.DemoModel
{

    public class MyType
    {
        
    }

    public class Ship
    {
        public MyType Position
        {
            get
            {
                return _Position;
            }
            set
            {
                _Position = value;
                foreach (var shipChanged in ChangeListeners)
                {
                    shipChanged.PositionChanged();
                }
            }
        }

        private MyType _Position { get; set; }
        public List<IShipChanged> ChangeListeners { get;private set; }
        public Ship(MyType position)
        {
            _Position = position;
            ChangeListeners= new List<IShipChanged>();
        }
    }
}