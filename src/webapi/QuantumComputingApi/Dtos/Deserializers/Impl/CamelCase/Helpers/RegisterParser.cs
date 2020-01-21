using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using QuantumComputingApi.Dtos.Impl.CamelCase.Helpers;

namespace QuantumComputingApi.Dtos.Deserializers.Impl.CamelCase.Helpers {
    public class RegisterParser : CiruitElementParser {
        public override ICircuitElementDto ParseCircuitElement(dynamic dynamicElement) {
            if (dynamicElement.type == "register") {

                List<IQubitDto> mappedQubits = new List<IQubitDto>();
                var index = 0;
                var dynamicQubits = dynamicElement.qubits;

                while (true) {
                    try {
                        var mappedQubit = mapQubit(dynamicQubits[index]);
                        mappedQubits.Add(mappedQubit);
                        index++;
                    } catch (Exception) {
                        break;
                    }
                }

                return new RegisterDto() {
                    Id = dynamicElement.id,
                    InputCount = dynamicElement.inputCount,
                    OutputCount = dynamicElement.outputCount,
                    Type = dynamicElement.type,
                    Qubits = mappedQubits
                };
            }

            if (_nextParser != null) {
                return _nextParser.ParseCircuitElement(dynamicElement);
            }

            return null;
        }

        private QubitDto mapQubit(dynamic qubit) {
            double oneReal = qubit.oneAmplitude.real;
            double oneImag = qubit.oneAmplitude.imaginary;
            double zeroReal = qubit.zeroAmplitude.real;
            double zeroImag = qubit.zeroAmplitude.imaginary;

            return new QubitDto() {

                OneAmplitude = new ComplexDto() {
                    Real = oneReal,
                    Imaginary = oneImag
                },
                ZeroAmplitude = new ComplexDto() {
                    Real = zeroReal,
                    Imaginary = zeroImag
                }
            };
        }
    }
}