using System.Collections.Generic;
using QuantumComputingApi.Dtos.Impl.SnakeCase;

namespace QuantumComputingApi.Dtos.Producer.Impl {
    public class SnakeCaseDtoProducer : DtoProducerBase {
        public override ICirquitDto ProduceCirquitDto() {
            return new CirquitDto() {
                Elements = new List<ICirquitElementDto>(),
                    Connections = new List<IConnectionDto>()
            };
        }

        public override ICirquitResultDto ProduceCirquitResultDto() {
            return new CirquitResultDto();
        }
    }
}