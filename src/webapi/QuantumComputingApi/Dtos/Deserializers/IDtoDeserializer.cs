using System;
using System.Threading.Tasks;
using QuantumComputingApi.Dtos;

namespace QuantumComputingApi.Dtos.Deserializers
{
    public interface IDtoDeserializer
    {
        Task<ICirquitDto> DeserializeFromText(string text);
    }
}