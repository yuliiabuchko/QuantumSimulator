using QuantumComputingApi.Dtos.Impl.CamelCase.Helpers;
using Newtonsoft.Json;

namespace QuantumComputingApi.Dtos.Deserializers.Impl.CamelCase.Helpers
{
    public class GateParser : CiruitElementParser
    {
        public override ICircuitElementDto ParseCircuitElement(dynamic dynamicElement)
        {
            if (dynamicElement.type == "gate") {
        
                return new GateDto() {
                    Id = dynamicElement.id,
                    InputCount = dynamicElement.inputCount,
                    OutputCount = dynamicElement.outputCount,
                    Type = dynamicElement.type,
                    GateName = dynamicElement.gateName
                };
            }

            if(_nextParser != null) {
                return _nextParser.ParseCircuitElement(dynamicElement);
            }

            return null;
        }
    }
}