using System;
using System.Collections.Generic;
using QuantumComputingApi.Dtos.Impl.SnakeCase.Helpers;

namespace QuantumComputingApi.Dtos.Deserializers.Impl.SnakeCase.Helpers {
    public class ConnectionParser {
        public IConnectionDto ParseConnection(dynamic dynamicConnection) {
            List<int?> mappedLeft = new List<int?>();
            var index = 0;
            var left = dynamicConnection.left_entries;

            while (true) {
                try {
                    int? mappedEntry = left[index];
                    mappedLeft.Add(mappedEntry);
                    index++;
                } catch (Exception) {
                    break;
                }
            }

            List<int?> mappedRight = new List<int?>();
            index = 0;
            var right = dynamicConnection.right_entries;

            while (true) {
                try {
                    int? mappedEntry = right[index];
                    mappedRight.Add(mappedEntry);
                    index++;
                } catch (Exception) {
                    break;
                }
            }
            return new ConnectionDto() {
                IdLeft = dynamicConnection.id_left,
                IdRight = dynamicConnection.id_right,
                LeftEntries = mappedLeft,
                RightEntries = mappedRight
            };
        }
    }
}