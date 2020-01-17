using System.Collections.Generic;

namespace QuantumComputingApi.Dtos {
    public interface ICirquitDto<out T, out U> 
        where T : ICirquitElementDto
        where U : IConnectionDto
    {
        IEnumerable<T> Elements { get; }
        IEnumerable <U> Connections { get; }
    }
}