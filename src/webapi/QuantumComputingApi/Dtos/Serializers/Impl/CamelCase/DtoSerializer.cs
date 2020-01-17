using System.Threading.Tasks;
using Newtonsoft.Json;
using QuantumComputingApi.Dtos.Impl.CamelCase.Helpers;
using QuantumComputingApi.Dtos.Impl.CamelCase;

namespace QuantumComputingApi.Dtos.Serializers.Impl.CamelCase {
    public class DtoSerializer : IDtoSerializer<CirquitElementDto, ConnectionDto, CirquitDto> {
        public Task<string> SerializeToText(CirquitDto cirquitDto) {
            throw new System.NotImplementedException();
        }
    }
}