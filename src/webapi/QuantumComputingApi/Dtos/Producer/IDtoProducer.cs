using System;
using QuantumComputingApi.Dtos.Deserializers;
using QuantumComputingApi.Dtos.Serializers;

namespace QuantumComputingApi.Dtos.Producer
{
    public interface IDtoProducer< out T, out  U, in Z>
        where T : ICirquitElementDto
        where U : IConnectionDto
        where Z : ICirquitDto<T, U>
    {
        ICirquitDto<ICirquitElementDto, IConnectionDto> ProduceCirquitDto();
        ICirquitResultDto ProduceCirquitResultDto();
        IDtoDeserializer ProduceDtoDeserializer();
        IDtoSerializer<T, U, Z> ProduceDtoSerializer();
    }
}