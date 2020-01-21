using System.Collections.Generic;

namespace QuantumComputingApi.Daos {
    public class ConnectionDao {
        public string IdLeft { get; set; }
        public IEnumerable<int?> LeftEntries { get; set; }
        public string IdRight { get; set; }
        public IEnumerable<int?> RightEntries { get; set; }
    }
}