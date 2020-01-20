using QuantumComputingApi.Dtos;
using QuantumComputingApi.Dtos.Producer;

namespace QuantumComputingApi.Utils
{
    public interface IProvider
    {
        public IDtoProducer<ICirquitElementDto, IConnectionDto, ICirquitDto<ICirquitElementDto, IConnectionDto>, IQubitDto, IRegisterDto<IQubitDto>, ICirquitResultDto<IQubitDto, IRegisterDto<IQubitDto>>> ProvideProducer();
    }
}