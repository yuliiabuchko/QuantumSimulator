using System;
using QuantumComputingApi.Daos;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace QuantumComputingApi.Repositories
{
    public interface ICirquitRepository
    {
        Task<IEnumerable<CirquitDao>> FindAllCirquits();
        Task<CirquitDao> FindCirquit(Guid Uuid);
        Task CreateCirquit(CirquitDao cirquit);
        Task<bool> UpdateCirquit(Guid Uuid, CirquitDao cirquit);
        Task<bool> DeleteCirquit(Guid Uuid);
    }
}