using System.Threading.Tasks;
using QuantumComputingApi.Dtos.Impl.SnakeCase.Helpers;
using QuantumComputingApi.Dtos.Impl.SnakeCase;
using Newtonsoft.Json;

namespace QuantumComputingApi.Dtos.Serializers.Impl.SnakeCase {
    public class DtoSerializer : IDtoSerializer {
        public Task<string> SerializeToText(ICircuitDto circuitDto) {
            return Task.FromResult(JsonConvert.SerializeObject(circuitDto));
        }

    }
}