using System.Threading.Tasks;
using Newtonsoft.Json;
using QuantumComputingApi.Dtos.Impl.CamelCase;

namespace QuantumComputingApi.Dtos.Deserializers.Impl.CamelCase {
    public class DtoDeserializer : IDtoDeserializer {
        public Task<ICirquitDto> DeserializeFromText(string text) {
            var mainBody = JsonConvert.DeserializeObject<CirquitDto>(text);
            

            return null;
        }
    }
}