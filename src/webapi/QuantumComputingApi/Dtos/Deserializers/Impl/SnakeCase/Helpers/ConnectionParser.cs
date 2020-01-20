using QuantumComputingApi.Dtos.Impl.SnakeCase.Helpers;

namespace QuantumComputingApi.Dtos.Deserializers.Impl.SnakeCase.Helpers
{
    public class ConnectionParser
    {
        public IConnectionDto ParseConnection(dynamic dynamicConnection) {
            return new ConnectionDto() {
                IdLeft = dynamicConnection.id_left,
                IdRight = dynamicConnection.id_right,
                LeftEntries = dynamicConnection.left_entries,
                RightEntries = dynamicConnection.right_entries
            };
        }
    }
}