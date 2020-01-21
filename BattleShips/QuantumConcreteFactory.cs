namespace BattleShips
{
    public class QuantumConcreteFactory : EngineFactory
    {
        public override IEngine MakeProduct()
        {
            IEngine product = new QuantumEngine();
            return product;
        }
    }
}