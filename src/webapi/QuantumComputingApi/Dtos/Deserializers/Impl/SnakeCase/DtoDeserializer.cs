using System.Threading.Tasks;
using Newtonsoft.Json;
using QuantumComputingApi.Dtos.Impl.SnakeCase;
using QuantumComputingApi.Dtos.Impl.SnakeCase.Helpers;

namespace QuantumComputingApi.Dtos.Deserializers.Impl.SnakeCase {
    public class DtoDeserializer : IDtoDeserializer<CirquitElementDto, ConnectionDto, CirquitDto> {

        public Task<CirquitDto> DeserializeFromText(string text)
        {
            return Task.FromResult(JsonConvert.DeserializeObject<CirquitDto>(text));
        }
    }
}