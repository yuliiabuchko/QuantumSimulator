namespace QuantumComputingApi.Dtos.Deserializers.Impl.CamelCase.Helpers {
    public class Parser {
        private CiruitElementParser _circuitElementParser;
        private ConnectionParser _connectionParser;

        public Parser(CiruitElementParser ciruitElementParser, ConnectionParser connectionParser) {
            _circuitElementParser = ciruitElementParser;
            _connectionParser = connectionParser;
        }

        public ICircuitElementDto ParseCircuitElement(dynamic element) {
            return _circuitElementParser.ParseCircuitElement(element);
        }

        public IConnectionDto ParseConnection(dynamic connection) {
            return _connectionParser.ParseConnection(connection);
        }
    }
}