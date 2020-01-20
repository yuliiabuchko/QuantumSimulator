using System;
using QuantumComputingApi.Daos;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace QuantumComputingApi.Repositories
{
    public interface ICircuitRepository
    {
        Task<IEnumerable<CircuitDao>> FindAllCircuits();
        Task<CircuitDao> FindCircuit(Guid Uuid);
        Task CreateCircuit(CircuitDao circuit);
        Task<bool> UpdateCircuit(Guid Uuid, CircuitDao circuit);
        Task<bool> DeleteCircuit(Guid Uuid);
    }
}