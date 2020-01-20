using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Formatters;
using QuantumComputingApi.Dtos.Deserializers;
using QuantumComputingApi.Dtos.Deserializers.Impl.SnakeCase;
using QuantumComputingApi.Dtos.Deserializers.Impl.SnakeCase.Helpers;
using QuantumComputingApi.Dtos.Impl.SnakeCase;
using QuantumComputingApi.Dtos.Impl.SnakeCase.Helpers;
using QuantumComputingApi.Dtos.Serializers;
using QuantumComputingApi.Dtos.Serializers.Impl.SnakeCase;

namespace QuantumComputingApi.Dtos.Producer.Impl {
    public class SnakeCaseDtoProducer : IDtoProducer
    {
        // public ICircuitDto ProduceCircuitDto() {
        //     return new CircuitDto() {
        //         Elements = new List<CircuitElementDto>(),
        //         Connections = new List<ConnectionDto>()
        //     };
        // }

        // public ICircuitResultDto ProduceCircuitResultDto() {
        //     return new CircuitResultDto();
        // }
        public IDtoDeserializer ProduceDeserializer()
        {
            var registerParser = new RegisterParser();
            var gateParser = new GateParser();
            gateParser.setNext(registerParser);

            var connectionParser = new ConnectionParser();

            var parser = new Parser(gateParser, connectionParser);
            
            return new DtoDeserializer(parser);
        }

        public IDtoSerializer ProduceSerializer()
        {
            return new DtoSerializer();
        }
    }
}