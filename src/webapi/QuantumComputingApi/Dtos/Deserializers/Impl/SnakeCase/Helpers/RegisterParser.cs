using QuantumComputingApi.Dtos.Impl.SnakeCase.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace QuantumComputingApi.Dtos.Deserializers.Impl.SnakeCase.Helpers
{
    public class RegisterParser : CiruitElementParser
    {
        public override ICircuitElementDto ParseCircuitElement(dynamic dynamicElement)
        {
            if (dynamicElement.type == "register") {
                List<dynamic> qubits = dynamicElement.qubits;
                return new RegisterDto() {
                    Id = dynamicElement.id,
                    InputCount = dynamicElement.input_count,
                    OutputCount = dynamicElement.output_count,
                    Type = dynamicElement.type,
                    Qubits = qubits.Select<dynamic, QubitDto>(qubit => mapQubit(qubit))
                };
            }

            if(_nextParser != null){
                return _nextParser.ParseCircuitElement(dynamicElement);
            }

            return null;
        }

        private QubitDto mapQubit (dynamic qubit) {
            return new QubitDto() {
                OneAmplitude = qubit.one_amplitude,
                ZeroAmplitude = qubit.zero_amplitude
            };
        }
    }
}