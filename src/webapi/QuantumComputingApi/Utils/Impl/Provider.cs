using QuantumComputingApi.Dtos;
using QuantumComputingApi.Dtos.Producer;
using QuantumComputingApi.Dtos.Producer.Impl;
using QuantumComputingApi.Utils;
using System;

namespace QuantumComputingApi.Utils.Impl
{
    public class Provider : IProvider
    {
        private readonly DtoType _dtoType;

        public Provider(DtoType dtoType) {
            _dtoType = dtoType;
        }
        public IDtoProducer<ICirquitElementDto, IConnectionDto, ICirquitDto<ICirquitElementDto, IConnectionDto>, ICirquitResultDto> ProvideProducer()
        {
            object producer = null;
            switch(_dtoType){
                case DtoType.CamelCase: {
                    producer = new CamelCaseDtoProducer();
                    break;
                }
                case DtoType.SnakeCase: {
                    producer = new SnakeCaseDtoProducer();
                    break;
                }
                default: {
                    throw new InvalidOperationException($"No support for {_dtoType.ToString()} is providden.");
                }
            }
            
            return (IDtoProducer<ICirquitElementDto, IConnectionDto, ICirquitDto<ICirquitElementDto, IConnectionDto>, ICirquitResultDto>) producer;
        }
    }
}