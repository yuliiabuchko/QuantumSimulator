using System;

namespace QuantumComputingApi.Dtos.Producer {
    public abstract class DtoProducerBase  {
        public abstract ICirquitDto ProduceCirquitDto();
        public abstract ICirquitResultDto ProduceCirquitResultDto();
    }
}