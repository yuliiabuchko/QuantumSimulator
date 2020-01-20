using System.Threading.Tasks;
using Newtonsoft.Json;
using QuantumComputingApi.Dtos.Impl.CamelCase.Helpers;
using QuantumComputingApi.Dtos.Impl.CamelCase;

namespace QuantumComputingApi.Dtos.Serializers.Impl.CamelCase {
    public class DtoSerializer : IDtoSerializer {
        public Task<string> SerializeToText(ICircuitDto circuitDto) {
            return Task.FromResult(JsonConvert.SerializeObject(circuitDto));
        }
    }
}