using QuantumComputingApi.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace QuantumComputingApi.Services {
    public interface ICirquitService {
        Task<IEnumerable<ICirquitDto>> GetAllCirquitsHandler();
        Task<ICirquitDto> GetCirquitHandler(Guid Id);
        Task<ICirquitDto> CreateCirquitHandler(ICirquitDto cirquitDto);
        Task<ICirquitDto> UpdateCirquitHandler(Guid Id, ICirquitDto cirquitDto);
        Task DeleteCirquitHandler(Guid Id);
        Task<ICirquitResultDto> ExecuteCirquitHandler(Guid Id);
    }
}