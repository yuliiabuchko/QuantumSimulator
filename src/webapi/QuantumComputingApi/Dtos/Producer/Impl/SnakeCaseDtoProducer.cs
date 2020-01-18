using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Formatters;
using QuantumComputingApi.Dtos.Deserializers;
using QuantumComputingApi.Dtos.Deserializers.Impl.SnakeCase;
using QuantumComputingApi.Dtos.Formatters;
using QuantumComputingApi.Dtos.Impl.SnakeCase;
using QuantumComputingApi.Dtos.Impl.SnakeCase.Helpers;
using QuantumComputingApi.Dtos.Serializers;
using QuantumComputingApi.Dtos.Serializers.Impl.SnakeCase;

namespace QuantumComputingApi.Dtos.Producer.Impl {
    public class SnakeCaseDtoProducer : IDtoProducer<CirquitElementDto, ConnectionDto, CirquitDto, CirquitResultDto> {
        public CirquitDto ProduceCirquitDto() {
            return new CirquitDto() {
                Elements = new List<CirquitElementDto>(),
                    Connections = new List<ConnectionDto>()
            };
        }

        public CirquitResultDto ProduceCirquitResultDto() {
            return new CirquitResultDto();
        }

        public TextInputFormatter ProduceTextInputFormatter() {
            return new DtoInputFormatter<CirquitElementDto, ConnectionDto, CirquitDto>(new DtoDeserializer());
        }

        public TextOutputFormatter ProduceTextOutputFormatter() {
            return new DtoOutputFormatter<CirquitElementDto, ConnectionDto, CirquitDto>(new DtoSerializer());
        }
    }
}