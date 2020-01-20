using System.Threading.Tasks;
using Newtonsoft.Json;
using System;
using QuantumComputingApi.Dtos.Impl.SnakeCase;
using QuantumComputingApi.Dtos.Impl.SnakeCase.Helpers;
using System.Collections.Generic;
using System.Linq;
using QuantumComputingApi.Dtos.Deserializers.Impl.SnakeCase.Helpers;

namespace QuantumComputingApi.Dtos.Deserializers.Impl.SnakeCase {
    public class DtoDeserializer : IDtoDeserializer {

        private Parser _parser;
        public DtoDeserializer(Parser parser) {
            _parser = parser;
        }
        public Task<ICircuitDto> DeserializeFromText(string text)
        {
             
            var data = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(text);
            dynamic dataD = JsonConvert.DeserializeObject(text);
            dynamic elements = dataD.elements;
            dynamic connections = dataD.connections;
            CircuitDto circuit = new CircuitDto() {
                // Elements = elements.Select<dynamic, CircuitElementDto>(element => _parser.ParseCircuitElement(element)),
                // Connections = connections.Select<dynamic, ConnectionDto>(connection => _parser.ParseConnection(connection))
            };
            
            return null;
        }

        //TODO : write function to iterate through dynamic and map it
    }
}