using System;
using QuantumComputingApi.Daos;
using QuantumComputingApi.Dtos;
using QuantumComputingApi.Dtos.Producer;

namespace QuantumComputingApi.Utils
{
    public class Mapper
        // <T, U, Z>
        // where T : ICirquitElementDto
        // where U : IConnectionDto
        // where Z : ICirquitDto<T, U>
    {

        public ICirquitDto<ICirquitElementDto, IConnectionDto> MapCirquitToDto(CirquitDao cirquitDao) {
            throw new NotImplementedException();
        }

        public CirquitDao MapCirquitToDao (ICirquitDto<ICirquitElementDto, IConnectionDto> cirquitDto) {
            throw new NotImplementedException();
        }
    }
}