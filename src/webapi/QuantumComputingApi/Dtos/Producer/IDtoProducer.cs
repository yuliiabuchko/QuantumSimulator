using System;
using Microsoft.AspNetCore.Mvc.Formatters;
using QuantumComputingApi.Dtos.Deserializers;
using QuantumComputingApi.Dtos.Serializers;

namespace QuantumComputingApi.Dtos.Producer {
    public interface IDtoProducer {
        IDtoDeserializer ProduceDeserializer();
        IDtoSerializer ProduceSerializer();

        ICircuitDto ProduceCircuitDto();
        IGageDto ProduceGateDto();
        IRegisterDto ProduceRegisterDto();
        IConnectionDto ProduceConnectionDto();
        IQubitDto ProduceQubitDto();
        IComplexDto ProduceComplexDto();
    }
}