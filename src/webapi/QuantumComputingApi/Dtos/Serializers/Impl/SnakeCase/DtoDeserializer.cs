using System.Threading.Tasks;
using Newtonsoft.Json;

namespace QuantumComputingApi.Dtos.Serializers.Impl.SnakeCase {
    public class DtoSerializer : IDtoSerializer {
        public Task<string> SerializeToText(ICircuitDto circuitDto) {
            return Task.FromResult(JsonConvert.SerializeObject(circuitDto));
        }
    }
}