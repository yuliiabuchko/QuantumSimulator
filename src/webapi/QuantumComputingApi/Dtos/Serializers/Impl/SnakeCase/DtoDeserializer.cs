using System.Threading.Tasks;
using QuantumComputingApi.Dtos.Impl.SnakeCase.Helpers;
using QuantumComputingApi.Dtos.Impl.SnakeCase;

namespace QuantumComputingApi.Dtos.Serializers.Impl.SnakeCase {
    public class DtoSerializer : IDtoSerializer<CirquitElementDto, ConnectionDto, CirquitDto> {
        public Task<string> SerializeToText(CirquitDto cirquitDto) {
            throw new System.NotImplementedException();
        }

    }
}