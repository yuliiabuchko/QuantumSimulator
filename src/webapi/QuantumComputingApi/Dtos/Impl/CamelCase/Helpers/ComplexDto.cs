using Newtonsoft.Json;

namespace QuantumComputingApi.Dtos.Impl.CamelCase.Helpers {
    public class ComplexDto : IComplexDto {

        [JsonProperty(PropertyName = "real")]
        public double Real { get; set; }

        [JsonProperty(PropertyName = "imaginary")]
        public double Imaginary { get; set; }
    }
}