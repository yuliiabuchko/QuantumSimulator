using QuantumComputingApi.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace QuantumComputingApi.Services {
    public interface ICirquitService {
        Task<IEnumerable<ICirquitDto<ICirquitElementDto, IConnectionDto>>> GetAllCirquitsHandler();
        Task<ICirquitDto<ICirquitElementDto, IConnectionDto>> GetCirquitHandler(Guid Uuid);
        Task<Guid?> CreateCirquitHandler(ICirquitDto<ICirquitElementDto, IConnectionDto> cirquitDto);
        Task<bool> UpdateCirquitHandler(Guid Uuid, ICirquitDto<ICirquitElementDto, IConnectionDto> cirquitDto);
        Task<bool> DeleteCirquitHandler(Guid Uuid);
        Task<ICirquitResultDto<IQubitDto, IRegisterDto<IQubitDto>>> ExecuteCirquitHandler(Guid Uuid);
    }
}