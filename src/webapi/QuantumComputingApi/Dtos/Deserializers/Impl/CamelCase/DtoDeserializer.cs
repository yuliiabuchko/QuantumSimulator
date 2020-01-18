using System.Threading.Tasks;
using Newtonsoft.Json;
using QuantumComputingApi.Dtos.Impl.CamelCase;
using QuantumComputingApi.Dtos.Impl.CamelCase.Helpers;

namespace QuantumComputingApi.Dtos.Deserializers.Impl.CamelCase {
    public class DtoDeserializer : IDtoDeserializer<CirquitElementDto, ConnectionDto, CirquitDto> {

        public Task<CirquitDto> DeserializeFromText(string text)
        {
            return Task.FromResult(JsonConvert.DeserializeObject<CirquitDto>(text));
        }
    }
}