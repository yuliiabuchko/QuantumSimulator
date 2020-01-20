using QuantumComputingApi.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace QuantumComputingApi.Services {
    public interface ICircuitService {
        Task<IEnumerable<ICircuitDto>> GetAllCircuitsHandler();
        Task<ICircuitDto> GetCircuitHandler(Guid Uuid);
        Task<Guid?> CreateCircuitHandler(ICircuitDto circuitDto);
        Task<bool> UpdateCircuitHandler(Guid Uuid, ICircuitDto circuitDto);
        Task<bool> DeleteCircuitHandler(Guid Uuid);
        Task<ICircuitResultDto> ExecuteCircuitHandler(Guid Uuid);
    }
}