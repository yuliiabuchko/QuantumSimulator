using System;
using System.Threading.Tasks;
using QuantumComputingApi.Dtos;

namespace QuantumComputingApi.Dtos.Serializers
{
    public interface IDtoSerializer<out T, out U, in Z> 
        where T : ICirquitElementDto
        where U : IConnectionDto
        where Z : ICirquitDto<T,U>
    {
        Task<string> SerializeToText(Z cirquitDto);
    }
}