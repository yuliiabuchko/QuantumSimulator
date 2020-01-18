using QuantumComputingApi.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace QuantumComputingApi.Services {
    public interface ICirquitService {
        Task<IEnumerable<ICirquitDto<ICirquitElementDto, IConnectionDto>>> GetAllCirquitsHandler();
        Task<ICirquitDto<ICirquitElementDto, IConnectionDto>> GetCirquitHandler(Guid Uuid);
        Task CreateCirquitHandler(ICirquitDto<ICirquitElementDto, IConnectionDto> cirquitDto);
        Task UpdateCirquitHandler(Guid Uuid, ICirquitDto<ICirquitElementDto, IConnectionDto> cirquitDto);
        Task DeleteCirquitHandler(Guid Uuid);
        Task<ICirquitResultDto> ExecuteCirquitHandler(Guid Uuid);
    }
}