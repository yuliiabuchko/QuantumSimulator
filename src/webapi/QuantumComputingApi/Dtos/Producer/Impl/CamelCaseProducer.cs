using System.Collections.Generic;
using QuantumComputingApi.Dtos.Impl.CamelCase;

namespace QuantumComputingApi.Dtos.Producer.Impl {
    public class CamelCaseDtoProducer : DtoProducerBase {
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