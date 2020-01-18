using System;
using QuantumComputingApi.Dtos.Deserializers;
using QuantumComputingApi.Dtos.Serializers;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace QuantumComputingApi.Dtos.Producer
{
    public interface IDtoProducer< out T, out  U, out Z, out V>
        where T : ICirquitElementDto
        where U : IConnectionDto
        where Z : ICirquitDto<T, U>
        where V : ICirquitResultDto
    {
        Z ProduceCirquitDto();
        V ProduceCirquitResultDto();
        TextInputFormatter ProduceTextInputFormatter();
        TextOutputFormatter ProduceTextOutputFormatter();


    }
}