using System;
using System.Threading.Tasks;
using QuantumComputingApi.Dtos;

namespace QuantumComputingApi.Dtos.Deserializers
{
    public interface IDtoDeserializer 
    {
        Task<ICircuitDto> DeserializeFromText(string text);
    }
}