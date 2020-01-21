using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Formatters;
using QuantumComputingApi.Dtos.Deserializers;
using QuantumComputingApi.Dtos.Deserializers.Impl.CamelCase;
using QuantumComputingApi.Dtos.Deserializers.Impl.CamelCase.Helpers;
using QuantumComputingApi.Dtos.Impl.CamelCase;
using QuantumComputingApi.Dtos.Impl.CamelCase.Helpers;
using QuantumComputingApi.Dtos.Serializers;
using QuantumComputingApi.Dtos.Serializers.Impl.CamelCase;

namespace QuantumComputingApi.Dtos.Producer.Impl {
    public class CamelCaseDtoProducer : IDtoProducer {
        public ICircuitDto ProduceCircuitDto() {
            return new CircuitDto();
        }

        public IConnectionDto ProduceConnectionDto() {
            return new ConnectionDto();
        }

        public IDtoDeserializer ProduceDeserializer() {
            var registerParser = new RegisterParser();
            var gateParser = new GateParser();
            gateParser.setNext(registerParser);

            var connectionParser = new ConnectionParser();

            var parser = new Parser(gateParser, connectionParser);

            return new DtoDeserializer(parser);
        }

        public IGageDto ProduceGateDto() {
            return new GateDto();
        }

        public IQubitDto ProduceQubitDto() {
            return new QubitDto();
        }

        public IRegisterDto ProduceRegisterDto() {
            return new RegisterDto();
        }

        public IDtoSerializer ProduceSerializer() {
            return new DtoSerializer();
        }

        public IComplexDto ProduceComplexDto() {
            return new ComplexDto();
        }
    }
}