using System.Collections.Generic;
using QuantumComputingApi.Dtos.Deserializers;
using QuantumComputingApi.Dtos.Deserializers.Impl.CamelCase;
using QuantumComputingApi.Dtos.Impl.CamelCase;
using QuantumComputingApi.Dtos.Serializers;
using QuantumComputingApi.Dtos.Serializers.Impl.CamelCase;

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

        public override IDtoDeserializer ProduceDtoDeserializer() {
            return new DtoDeserializer();
        }

        public override IDtoSerializer ProduceDtoSerializer()
        {
            return new DtoSerializer();
        }
    }
}