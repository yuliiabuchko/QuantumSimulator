using System.Threading.Tasks;
using QuantumComputingApi.Dtos.Impl.SnakeCase.Helpers;
using QuantumComputingApi.Dtos.Impl.SnakeCase;
using Newtonsoft.Json;

namespace QuantumComputingApi.Dtos.Serializers.Impl.SnakeCase {
    public class DtoSerializer : IDtoSerializer<CirquitElementDto, ConnectionDto, CirquitDto> {
        public Task<string> SerializeToText(CirquitDto cirquitDto) {
            return Task.FromResult(JsonConvert.SerializeObject(cirquitDto));
        }

    }
}