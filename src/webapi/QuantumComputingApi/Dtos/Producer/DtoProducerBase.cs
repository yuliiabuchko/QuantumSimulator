using System;
using QuantumComputingApi.Dtos.Deserializers;
using QuantumComputingApi.Dtos.Serializers;

namespace QuantumComputingApi.Dtos.Producer {
    public abstract class DtoProducerBase  {
        public abstract ICirquitDto ProduceCirquitDto();
        public abstract ICirquitResultDto ProduceCirquitResultDto();
        public abstract IDtoDeserializer ProduceDtoDeserializer();
        public abstract IDtoSerializer ProduceDtoSerializer();
    }
}