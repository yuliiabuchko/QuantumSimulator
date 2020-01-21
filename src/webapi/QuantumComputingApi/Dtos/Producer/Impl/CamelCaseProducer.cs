using QuantumComputingApi.Dtos.Deserializers;
using QuantumComputingApi.Dtos.Deserializers.Impl.CamelCase;
using QuantumComputingApi.Dtos.Deserializers.Impl.CamelCase.Helpers;
using QuantumComputingApi.Dtos.Impl.CamelCase;
using QuantumComputingApi.Dtos.Impl.CamelCase.Helpers;
using QuantumComputingApi.Dtos.Serializers;
using QuantumComputingApi.Dtos.Serializers.Impl.CamelCase;

namespace QuantumComputingApi.Dtos.Producer.Impl {
    public class CamelCaseDtoProducer : DtoProducerBase {
        public override ICircuitDto ProduceCircuitDto() {
            return new CircuitDto();
        }

        public override IConnectionDto ProduceConnectionDto() {
            return new ConnectionDto();
        }

        public override IDtoDeserializer ProduceDeserializer() {
            var registerParser = new RegisterParser();
            var gateParser = new GateParser();
            gateParser.setNext(registerParser);

            var connectionParser = new ConnectionParser();

            var parser = new Parser(gateParser, connectionParser);

            return new DtoDeserializer(parser);
        }

        public override IGageDto ProduceGateDto() {
            return new GateDto();
        }

        public override IQubitDto ProduceQubitDto() {
            return new QubitDto();
        }

        public override IRegisterDto ProduceRegisterDto() {
            return new RegisterDto();
        }

        public override IDtoSerializer ProduceSerializer() {
            return new DtoSerializer();
        }

        public override IComplexDto ProduceComplexDto() {
            return new ComplexDto();
        }

        public override ICircuitResultDto ProcudeCircuitResultDto() {
            return new CircuitResultDto();
        }

        // protected override DtoProducerBase CreateInstance()
        // {
        //     return new CamelCaseDtoProducer();
        // }
    }
}