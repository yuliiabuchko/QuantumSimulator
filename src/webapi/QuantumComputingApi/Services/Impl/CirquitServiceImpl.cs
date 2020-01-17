using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QuantumComputingApi.Dtos;

namespace QuantumComputingApi.Services.Impl {
    public class CirquitServiceImpl : ICirquitService {
        public Task<ICirquitDto> CreateCirquitHandler(ICirquitDto cirquitDto) {
            throw new NotImplementedException();
        }

        public Task DeleteCirquitHandler(Guid Id) {
            throw new NotImplementedException();
        }

        public Task<ICirquitResultDto> ExecuteCirquitHandler(Guid Id) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ICirquitDto>> GetAllCirquitsHandler() {
            throw new NotImplementedException();
        }

        public Task<ICirquitDto> GetCirquitHandler(Guid Id) {
            throw new NotImplementedException();
        }

        public Task<ICirquitDto> UpdateCirquitHandler(Guid Id, ICirquitDto cirquitDto) {
            throw new NotImplementedException();
        }
    }
}