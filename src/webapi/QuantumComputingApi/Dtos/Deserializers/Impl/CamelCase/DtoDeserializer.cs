using System.Threading.Tasks;
using Newtonsoft.Json;
using QuantumComputingApi.Dtos.Impl.CamelCase;
using QuantumComputingApi.Dtos.Impl.CamelCase.Helpers;
using System;

namespace QuantumComputingApi.Dtos.Deserializers.Impl.CamelCase {
    public class DtoDeserializer : IDtoDeserializer {

        public Task<ICircuitDto> DeserializeFromText(string text)
        {
            throw new NotImplementedException();
            // return Task.FromResult((ICirquitDto)JsonConvert.DeserializeObject<CirquitDto>(text));
        }
    }
}