namespace BattleShips
{
    public class SimpleConcreteFactory : EngineFactory
    {
        public override IEngine MakeProduct()
        {
            IEngine product = new simpeEngine();
            return product;
        }
    }
}