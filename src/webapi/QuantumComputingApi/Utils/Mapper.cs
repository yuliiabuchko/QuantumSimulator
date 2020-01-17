using System;
using QuantumComputingApi.Daos;
using QuantumComputingApi.Dtos;
using QuantumComputingApi.Dtos.Producer;

namespace QuantumComputingApi.Utils
{
    public class Mapper
    {
        private readonly DtoProducerBase _dtoProducer;

        public Mapper(DtoProducerBase dtoProducer) {
            _dtoProducer = dtoProducer;
        }

        public ICirquitDto MapCirquitToDto(CirquitDao cirquitDao) {
            throw new NotImplementedException();
        }

        public CirquitDao MapCirquitToDao (ICirquitDto cirquitDto) {
            throw new NotImplementedException();
        }
    }
}