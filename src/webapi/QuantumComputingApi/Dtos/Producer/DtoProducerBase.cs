using System;
using Microsoft.AspNetCore.Mvc.Formatters;
using QuantumComputingApi.Dtos.Deserializers;
using QuantumComputingApi.Dtos.Serializers;

namespace QuantumComputingApi.Dtos.Producer {
    public abstract class DtoProducerBase {

        // it should be singleton
        // protected DtoProducerBase() {}
        // private DtoProducerBase _instance = null;

        // // delegate creating actual instance to deriving classes
        // public DtoProducerBase GetInstance() {
        //     if(_instance == null) {
        //         _instance = CreateInstance();
        //     }

        //     return _instance;
        // }

        // protected abstract DtoProducerBase CreateInstance();
        public abstract IDtoDeserializer ProduceDeserializer();
        public abstract IDtoSerializer ProduceSerializer();

        public abstract ICircuitDto ProduceCircuitDto();
        public abstract IGageDto ProduceGateDto();
        public abstract IRegisterDto ProduceRegisterDto();
        public abstract IConnectionDto ProduceConnectionDto();
        public abstract IQubitDto ProduceQubitDto();
        public abstract IComplexDto ProduceComplexDto();
        public abstract ICircuitResultDto ProcudeCircuitResultDto();
    }
}