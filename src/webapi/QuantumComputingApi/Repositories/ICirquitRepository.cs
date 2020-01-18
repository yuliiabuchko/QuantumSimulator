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
        Task<CirquitDao> CreateCirquit(CirquitDao cirquit);
        Task<CirquitDao> UpdateCirquit(Guid Uuid, CirquitDao cirquit);
        Task<CirquitDao> DeleteCirquit(Guid Uuid);
    }
}