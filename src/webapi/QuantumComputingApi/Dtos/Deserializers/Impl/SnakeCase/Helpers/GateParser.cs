using QuantumComputingApi.Dtos.Impl.SnakeCase.Helpers;

namespace QuantumComputingApi.Dtos.Deserializers.Impl.SnakeCase.Helpers
{
    public class GateParser : CiruitElementParser
    {
        public override ICircuitElementDto ParseCircuitElement(dynamic dynamicElement)
        {
            if (dynamicElement.type == "gate") {
        
                return new GateDto() {
                    Id = dynamicElement.id,
                    InputCount = dynamicElement.input_count,
                    OutputCount = dynamicElement.output_count,
                    Type = dynamicElement.type,
                    GateName = dynamicElement.gate_name
                };
            }

            if(_nextParser != null) {
                return _nextParser.ParseCircuitElement(dynamicElement);
            }

            return null;
        }
    }
}