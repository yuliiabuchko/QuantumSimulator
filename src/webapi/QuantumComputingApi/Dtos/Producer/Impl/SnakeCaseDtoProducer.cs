using System.Collections.Generic;
using QuantumComputingApi.Dtos.Deserializers;
using QuantumComputingApi.Dtos.Deserializers.Impl.SnakeCase;
using QuantumComputingApi.Dtos.Impl.SnakeCase.Helpers;
using QuantumComputingApi.Dtos.Impl.SnakeCase;
using QuantumComputingApi.Dtos.Serializers;
using QuantumComputingApi.Dtos.Serializers.Impl.SnakeCase;

namespace QuantumComputingApi.Dtos.Producer.Impl {
    public class SnakeCaseDtoProducer : IDtoProducer<CirquitElementDto, ConnectionDto, CirquitDto> {
        public ICirquitDto<ICirquitElementDto, IConnectionDto> ProduceCirquitDto() {
            return new CirquitDto() {
                Elements = new List<CirquitElementDto>(),
                Connections = new List<ConnectionDto>()
            };
        }

        public ICirquitResultDto ProduceCirquitResultDto() {
            return new CirquitResultDto();
        }

        public IDtoDeserializer ProduceDtoDeserializer() {
            return new DtoDeserializer();
        }

        public IDtoSerializer<CirquitElementDto, ConnectionDto, CirquitDto> ProduceDtoSerializer() {
            return new DtoSerializer();
        }
    }
}