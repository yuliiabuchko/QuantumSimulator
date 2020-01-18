using System;
using System.Threading.Tasks;
using QuantumComputingApi.Dtos;

namespace QuantumComputingApi.Dtos.Deserializers
{
    public interface IDtoDeserializer<out T, out U, Z> 
        where T : ICirquitElementDto
        where U : IConnectionDto
        where Z : ICirquitDto<T,U>
    {
        Task<Z> DeserializeFromText(string text);
    }
}