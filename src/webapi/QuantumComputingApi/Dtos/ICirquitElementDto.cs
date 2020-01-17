using System.Collections.Generic;

namespace QuantumComputingApi.Dtos
{
    public interface ICirquitElementDto
    {
        string Id { get; set; }
        int? InputCount { get; set; }
        int? OutputCount { get; set; }
    }
}