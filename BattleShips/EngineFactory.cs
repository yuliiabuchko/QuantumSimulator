namespace BattleShips
{
    public abstract class EngineFactory
    {
        public abstract IEngine MakeProduct();

        public IEngine GetObject() // Implementation of Factory Method.
        {
            return this.MakeProduct();
        }
    }
}