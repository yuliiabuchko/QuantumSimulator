namespace QuantumComputingApi.Dtos.Deserializers.Impl.SnakeCase.Helpers
{
    public abstract class CiruitElementParser
    {
        protected CiruitElementParser _nextParser;

        public void setNext(CiruitElementParser nextParser) {
            _nextParser = nextParser;
        }

        public abstract ICircuitElementDto ParseCircuitElement(dynamic dynamicElement);
    }
}