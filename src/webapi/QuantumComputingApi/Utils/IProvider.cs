using QuantumComputingApi.Dtos;
using QuantumComputingApi.Dtos.Producer;

namespace QuantumComputingApi.Utils
{
    public interface IProvider
    {
        public IDtoProducer ProvideProducer();
    }
}