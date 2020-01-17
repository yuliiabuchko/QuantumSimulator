using System.Collections.Generic;

namespace QuantumComputingApi.Dtos.Impl.SnakeCase
{
    public class SnakeCaseCirquitDto : ICirquitDto
    {
        public IEnumerable<ICirquitElementDto> Elements { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<IConnectionDto> Connections { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}