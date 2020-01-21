using System.Collections.Generic;

namespace BattleShips
{
    public abstract class BatleShipGame
    {
        IEngine _engine;
        protected static int PlayersNumber = 2;
        protected static int ShipsNumber = 3;
        protected static int ShipSlotsNumber = 5;
        protected BatleShipGame(EngineFactory factory)
        {
            _engine = factory.MakeProduct();
        }
        protected List<List<int>> _shipsPos = new List<List<int>>();
        protected List<List<int>> _bombs = new List<List<int>>();
        public abstract void Play();
        protected List<List<int>> CountState()
        {
            return _engine.CountState(_shipsPos, _bombs);
        }

    }
}