using System.Threading.Tasks;
using Newtonsoft.Json;
using System;
using QuantumComputingApi.Dtos.Impl.CamelCase;
using QuantumComputingApi.Dtos.Impl.CamelCase.Helpers;
using System.Collections.Generic;
using System.Linq;
using QuantumComputingApi.Dtos.Deserializers.Impl.CamelCase.Helpers;

namespace QuantumComputingApi.Dtos.Deserializers.Impl.CamelCase {
    public class DtoDeserializer : IDtoDeserializer {

        private Parser _parser;
        public DtoDeserializer(Parser parser) {
            _parser = parser;
        }
        public Task<ICircuitDto> DeserializeFromText(string text)
        {
             
            var data = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(text);
            var elements = data["elements"];
            var connections = data["connections"];

            var index = 0;
            var mappedElements = new List<ICircuitElementDto>();

            while(true) {
                try {
                    var mapped = _parser.ParseCircuitElement(elements[index]);
                    mappedElements.Add(mapped);
                    
                    index++;
                }catch(Exception){
                    break;
                }
            }


            index = 0;
            var mappedConnections = new List<IConnectionDto>();

            while(true) {
                try {
                    var mapped = _parser.ParseConnection(connections[index]);
                    mappedConnections.Add(mapped);
                    
                    index++;
                }catch(Exception){
                    break;
                }
            }

            ICircuitDto circuit = new CircuitDto() {
                Elements = mappedElements,
                Connections = mappedConnections
            };
            
            
            return Task.FromResult(circuit);
        }
    }
}