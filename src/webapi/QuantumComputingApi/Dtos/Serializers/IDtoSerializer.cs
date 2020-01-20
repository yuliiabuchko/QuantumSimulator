using System;
using System.Threading.Tasks;
using QuantumComputingApi.Dtos;

namespace QuantumComputingApi.Dtos.Serializers
{
    public interface IDtoSerializer
    {
        Task<string> SerializeToText(ICircuitDto circuitDto);
    }
}