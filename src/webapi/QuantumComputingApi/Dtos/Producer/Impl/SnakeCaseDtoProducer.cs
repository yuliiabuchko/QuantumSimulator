using QuantumComputingApi.Dtos.Impl.SnakeCase;

namespace QuantumComputingApi.Dtos.Producer.Impl {
    public class SnakeCaseDtoProducer : DtoProducerBase {
        public override ICirquitDto ProduceCirquitDto() {
            return new SnakeCaseCirquitDto();
        }

        public override ICirquitResultDto ProduceCirquitResultDto() {
            return new SnakeCaseCirquitResultDto();
        }
    }
}