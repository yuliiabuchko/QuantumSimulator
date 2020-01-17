using QuantumComputingApi.Dtos.Impl.CamelCase;

namespace QuantumComputingApi.Dtos.Producer.Impl {
    public class CamelCaseDtoProducer : DtoProducerBase {
        public override ICirquitDto ProduceCirquitDto() {
            return new CirquitDto();
        }

        public override ICirquitResultDto ProduceCirquitResultDto() {
            return new CirquitResultDto();
        }
    }
}