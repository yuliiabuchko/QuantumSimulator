using System.Threading.Tasks;

namespace QuantumComputingApi.Dtos.Serializers {
    public interface IDtoSerializer {
        Task<string> SerializeToText(ICircuitDto circuitDto);
    }
}