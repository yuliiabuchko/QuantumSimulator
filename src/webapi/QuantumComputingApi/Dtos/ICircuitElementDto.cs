using System.Collections.Generic;

namespace QuantumComputingApi.Dtos
{
    public interface ICircuitElementDto
    {
        string Type { get; set; }
        string Id { get; set; }
        int? InputCount { get; set; }
        int? OutputCount { get; set; }
    }
}