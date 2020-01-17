using QuantumComputingApi.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace QuantumComputingApi.Services {
    public interface ICirquitService {
        Task<IEnumerable<ICirquitDto<ICirquitElementDto, IConnectionDto>>> GetAllCirquitsHandler();
        Task<ICirquitDto<ICirquitElementDto, IConnectionDto>> GetCirquitHandler(Guid Id);
        Task<ICirquitDto<ICirquitElementDto, IConnectionDto>> CreateCirquitHandler(ICirquitDto<ICirquitElementDto, IConnectionDto> cirquitDto);
        Task<ICirquitDto<ICirquitElementDto, IConnectionDto>> UpdateCirquitHandler(Guid Id, ICirquitDto<ICirquitElementDto, IConnectionDto> cirquitDto);
        Task DeleteCirquitHandler(Guid Id);
        Task<ICirquitResultDto> ExecuteCirquitHandler(Guid Id);
    }
}