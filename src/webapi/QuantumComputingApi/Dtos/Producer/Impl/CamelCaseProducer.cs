using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Formatters;
using QuantumComputingApi.Dtos.Deserializers;
using QuantumComputingApi.Dtos.Deserializers.Impl.CamelCase;
using QuantumComputingApi.Dtos.Impl.CamelCase;
using QuantumComputingApi.Dtos.Impl.CamelCase.Helpers;
using QuantumComputingApi.Dtos.Serializers;
using QuantumComputingApi.Dtos.Serializers.Impl.CamelCase;

namespace QuantumComputingApi.Dtos.Producer.Impl {
    public class CamelCaseDtoProducer : IDtoProducer
    {
        // public ICircuitDto ProduceCircuitDto() {
        //     return new CircuitDto() {
        //         Elements = new List<CircuitElementDto>(),
        //         Connections = new List<ConnectionDto>()
        //     };
        // }

        // public ICircuitResultDto ProduceCircuitResultDto() {
        //     return new CircuitResultDto();
        // }
        public IDtoDeserializer ProduceDeserializer()
        {
            throw new System.NotImplementedException();
        }

        public IDtoSerializer ProduceSerializer()
        {
            throw new System.NotImplementedException();
        }
    }
}